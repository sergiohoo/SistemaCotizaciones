using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaCotizaciones.Model;
using SistemaCotizaciones.Models;

namespace SistemaCotizaciones.Controllers
{
    public class CotizacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CotizacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult MaterialDelete(int id, int idCotizacion)
        {
            var materialDelete = _context.MaterialesCotizacion.Where(m => m.CotizacionId == idCotizacion && m.MaterialCotizacionId == id).FirstOrDefault();
            if (materialDelete != null)
            {
                _context.Remove(materialDelete);
                _context.SaveChanges();
            }

            var cotizacion = _context.Cotizaciones.Where(c => c.CotizacionId == idCotizacion).FirstOrDefault();
            var materiales = _context.MaterialesCotizacion.Where(m => m.CotizacionId == idCotizacion).ToList();
            decimal totalNeto = 0;
            decimal totalIva = 0;
            foreach (var material in materiales)
            {
                totalNeto += material.TotalNeto ?? 0;
            }
            totalIva = totalNeto * (1 + 19 / 100);

            cotizacion.TotalNeto = totalNeto;
            cotizacion.TotalIVA = totalIva;

            _context.Update(cotizacion);
            _context.SaveChanges();

            return RedirectToAction(nameof(Edit), new { id = idCotizacion });
        }

        public IActionResult PDF(int id)
        {
            var cotizacion = _context.Cotizaciones.Where(c => c.CotizacionId == id).Include(c => c.Usuario).Include(c => c.MaterialesCotizacion).ThenInclude(m => m.Material).Include(c => c.ClienteFinal).Include(c => c.Canal).Include(c => c.ContactoCanal).FirstOrDefault();
            var model = new CotizacionExcelViewModel
            {
                cotizacion = cotizacion
            };

            return View(model);
        }

        public IActionResult Excel(int id)
        {
            var cotizacion = _context.Cotizaciones.Where(c => c.CotizacionId == id).Include(c => c.Usuario).Include(c => c.MaterialesCotizacion).ThenInclude(m => m.Material).Include(c => c.ClienteFinal).Include(c => c.Canal).Include(c => c.ContactoCanal).FirstOrDefault();
            var model = new CotizacionExcelViewModel
            {
                cotizacion = cotizacion
            };

            return View(model);
        }

        [HttpGet]
        public JsonResult GetContactosFabricante(int fabricanteId)
        {
            var contactos = _context.ContactosFabricantes.Where(c => c.FabricanteId == fabricanteId).ToList();
            var result = new JsonResult(contactos);
            return result;
        }

        [HttpGet]
        public JsonResult GetContactosCanal(int canalId)
        {
            var contactos = _context.ContactosCanales.Where(c => c.CanalId == canalId).ToList();
            var result = new JsonResult(contactos);
            return result;
        }

        [HttpGet]
        public JsonResult GetContactosClienteFinal(int clienteId)
        {
            var contactos = _context.ContactosClientesFinales.Where(c => c.ClienteFinalId == clienteId).ToList();
            var result = new JsonResult(contactos);
            return result;
        }

        [HttpGet]
        public JsonResult AddMaterial(string json)
        {
            var result = new JsonResult("0");
            if (json != "")
            {
                var nMaterial = Newtonsoft.Json.JsonConvert.DeserializeObject<Material>(json);
                if (nMaterial != null)
                {
                    _context.Materiales.Add(nMaterial);
                    _context.SaveChanges();
                    result = new JsonResult(nMaterial.MaterialId);
                }
            }
            return result;
        }

        [HttpGet]
        public JsonResult AddCanal(string json)
        {
            var result = new JsonResult("0");
            if (json != "")
            {
                var nCanal = Newtonsoft.Json.JsonConvert.DeserializeObject<Canal>(json);
                if (nCanal != null)
                {
                    nCanal.RazonSocial = nCanal.RazonSocial.ToUpper();

                    _context.Canales.Add(nCanal);
                    _context.SaveChanges();
                    result = new JsonResult(nCanal.CanalId);
                }
            }
            return result;
        }

        [HttpGet]
        public JsonResult AddContactoCanal(string json)
        {
            var result = new JsonResult("0");
            if (json != "")
            {
                var nContactoCanal = Newtonsoft.Json.JsonConvert.DeserializeObject<ContactoCanal>(json);
                if (nContactoCanal != null)
                {
                    _context.ContactosCanales.Add(nContactoCanal);
                    _context.SaveChanges();
                    result = new JsonResult(nContactoCanal.ContactoCanalId);
                }
            }
            return result;
        }

        [HttpGet]
        public JsonResult AddClienteFinal(string json)
        {
            var result = new JsonResult("0");
            if (json != "")
            {
                var nClienteFinal = Newtonsoft.Json.JsonConvert.DeserializeObject<ClienteFinal>(json);
                if (nClienteFinal != null)
                {
                    nClienteFinal.RazonSocial = nClienteFinal.RazonSocial.ToUpper();

                    _context.ClientesFinales.Add(nClienteFinal);
                    _context.SaveChanges();
                    result = new JsonResult(nClienteFinal.ClienteFinalId);
                }
            }
            return result;
        }

        [HttpGet]
        public JsonResult AddContactoClienteFinal(string json)
        {
            var result = new JsonResult("0");
            if (json != "")
            {
                var nContactoClienteFinal = Newtonsoft.Json.JsonConvert.DeserializeObject<ContactoClienteFinal>(json);
                if (nContactoClienteFinal != null)
                {
                    _context.ContactosClientesFinales.Add(nContactoClienteFinal);
                    _context.SaveChanges();
                    result = new JsonResult(nContactoClienteFinal.ContactoClienteFinalId);
                }
            }
            return result;
        }

        // GET: Cotizaciones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cotizaciones.Include(c => c.Canal).Include(c => c.ClienteFinal).Include(c => c.ContactoCanal).Include(c => c.ContactoClienteFinal).Include(c => c.Fabricante).Include(c => c.Quote).Include(c => c.TipoCompra).Include(c => c.TipoCotizacion).Include(c => c.Usuario).OrderByDescending(c => c.CotizacionId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cotizaciones/Create
        public IActionResult Create()
        {
            ViewData["CanalId"] = new SelectList(_context.Canales, "CanalId", nameof(Canal.RazonSocial));
            ViewData["ClienteFinalId"] = new SelectList(_context.ClientesFinales, "ClienteFinalId", nameof(ClienteFinal.RazonSocial));
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre));
            ViewData["TipoCompraId"] = new SelectList(_context.TiposCompra, "TipoCompraId", nameof(TipoCompra.Nombre));
            ViewData["TipoCotizacionId"] = new SelectList(_context.TiposCotizacion, "TipoCotizacionId", nameof(TipoCotizacion.Nombre));
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", nameof(Usuario.NombreUsuario));

            var listaMateriales = _context.Materiales.OrderBy(m => m.Sku).ToList();
            var selectListMateriales = new List<SelectListItem>();
            foreach (var material in listaMateriales)
            {
                var texto = material.Sku + " | " + material.Descripcion;

                var itemMaterial = new SelectListItem
                {
                    Text = texto,
                    Value = material.MaterialId.ToString()
                };

                selectListMateriales.Add(itemMaterial);
            }


            ViewData["Materiales"] = new SelectList(selectListMateriales, "Value", "Text");

            var cotizacion = new Cotizacion();
            var materiales = new List<MaterialCotizacion>();
            for (int i = 0; i < 100; i++)
            {
                var material = new MaterialCotizacion
                {
                    FechaInicio = DateTime.Now,
                    FechaTermino = DateTime.Now.AddDays(30),
                    Cantidad = 0,
                    ImpuestoDuty = 0,
                    PrecioUnitario = 0,
                    DescuentoPorcentaje = 0
                };
                materiales.Add(material);
            }
            cotizacion.MaterialesCotizacion = materiales;

            var model = new CotizacionCreateViewModel
            {
                Cotizacion = cotizacion,
                Quote = new Quote
                {
                    FechaEmision = DateTime.Now.Date
                }
            };

            return View(model);
        }

        // POST: Cotizaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cotizacion cotizacion, Quote quote)
        {
            if (cotizacion != null && quote != null)
            {
                quote.Vigencia = true;
                _context.Add(quote);
                await _context.SaveChangesAsync();

                cotizacion.QuoteId = quote.QuoteId;
                cotizacion.FabricanteId = quote.FabricanteId;
                cotizacion.Version = 1;

                var materialesCotizacion = new List<MaterialCotizacion>();

                foreach (var material in cotizacion.MaterialesCotizacion)
                {
                    if (material.Cantidad != null && material.Cantidad > 0)
                    {
                        material.CotizacionId = cotizacion.CotizacionId;

                        decimal? precioUnitario = material.PrecioUnitario;
                        decimal? descuento = material.DescuentoPorcentaje;

                        decimal precioFob = 0;
                        decimal.TryParse((precioUnitario * (1 - descuento / 100))?.ToString("N2"), out precioFob);

                        decimal? interCompany = precioFob * 2 / 1000;
                        if (material.TipoMaterial == "HW")
                        {
                            interCompany = precioFob * 8 / 1000;
                        }

                        decimal? montoInternacion = precioFob * material.ImpuestoDuty * 1 / 100;
                        if (material.TipoMaterial == "SW")
                        {
                            montoInternacion = 0;
                        }

                        decimal? unoPorcientoFinanciero = precioFob * 1 / 100;
                        decimal? costoTotal = interCompany + unoPorcientoFinanciero + montoInternacion + precioFob;

                        // TIPO DE COTIZACIÓN DIRECTA:
                        if (cotizacion.TipoCotizacionId == 1)
                        {
                            costoTotal = unoPorcientoFinanciero + montoInternacion + precioFob;
                        }

                        decimal? costoFinalTotal = costoTotal * material.Cantidad;

                        decimal? totalSale = material.TotalNeto;

                        decimal? margen = 100 * (totalSale - costoFinalTotal) / totalSale;

                        material.PrecioFob = precioFob;
                        material.Intercompany = interCompany;
                        material.MontoInternacion = montoInternacion;
                        material.UnoPorcientoFinanciero = unoPorcientoFinanciero;
                        material.CostoTotal = costoTotal;
                        material.TotalCompra = material.TotalCompra;
                        material.CostoFinalTotal = costoFinalTotal;
                        material.Margen = margen;

                        materialesCotizacion.Add(material);
                    }
                }

                cotizacion.MaterialesCotizacion = materialesCotizacion;

                _context.Add(cotizacion);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }

            ViewData["CanalId"] = new SelectList(_context.Canales, "CanalId", nameof(Canal.RazonSocial), cotizacion.CanalId);
            ViewData["ContactoCanalId"] = new SelectList(_context.ContactosCanales.Where(c => c.CanalId == cotizacion.CanalId), "ContactoCanalId", nameof(ContactoCanal.Nombre), cotizacion.ContactoCanalId);
            ViewData["ClienteFinalId"] = new SelectList(_context.ClientesFinales, "ClienteFinalId", nameof(ClienteFinal.RazonSocial), cotizacion.ClienteFinalId);
            ViewData["ContactoClienteFinalId"] = new SelectList(_context.ContactosClientesFinales.Where(c => c.ClienteFinalId == cotizacion.ClienteFinalId), "ContactoClienteFinalId", nameof(ContactoClienteFinal.Nombre), cotizacion.ContactoClienteFinalId);
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre), cotizacion.FabricanteId);
            ViewData["QuoteId"] = new SelectList(_context.Quotes, "QuoteId", nameof(Quote.NumeroQuote), cotizacion.QuoteId);
            ViewData["TipoCompraId"] = new SelectList(_context.TiposCompra, "TipoCompraId", nameof(TipoCompra.Nombre), cotizacion.TipoCompraId);
            ViewData["TipoCotizacionId"] = new SelectList(_context.TiposCotizacion, "TipoCotizacionId", nameof(TipoCotizacion.Nombre), cotizacion.TipoCotizacionId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", nameof(Usuario.NombreUsuario), cotizacion.UsuarioId);
            return View(cotizacion);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> GuardaVersion(Cotizacion cotizacion, Quote quote)
        {
            if (cotizacion != null && quote != null)
            {
                //cotizacion.CanalId = 0;
                foreach (var material in cotizacion.MaterialesCotizacion)
                {
                    material.MaterialCotizacionId = 0;
                    material.CotizacionId = 0;
                }

                _context.Update(quote);
                await _context.SaveChangesAsync();

                cotizacion.CotizacionId = 0;
                cotizacion.QuoteId = quote.QuoteId;
                cotizacion.FabricanteId = quote.FabricanteId;

                var anteriores = _context.Cotizaciones.Where(c => c.QuoteId == quote.QuoteId).OrderByDescending(c => c.Version).FirstOrDefault();

                cotizacion.Version = anteriores.Version + 1;

                var materialesCotizacion = new List<MaterialCotizacion>();

                foreach (var material in cotizacion.MaterialesCotizacion)
                {
                    if (material.Cantidad != null && material.Cantidad > 0)
                    {
                        material.CotizacionId = cotizacion.CotizacionId;

                        decimal? precioUnitario = material.PrecioUnitario;
                        decimal? descuento = material.DescuentoPorcentaje;

                        decimal precioFob = 0;
                        decimal.TryParse((precioUnitario * (1 - descuento / 100))?.ToString("N2"), out precioFob);

                        decimal? interCompany = precioFob * 2 / 1000;
                        if (material.TipoMaterial == "HW")
                        {
                            interCompany = precioFob * 8 / 1000;
                        }

                        decimal? montoInternacion = precioFob * material.ImpuestoDuty * 1 / 100;
                        if (material.TipoMaterial == "SW")
                        {
                            montoInternacion = 0;
                        }

                        decimal? unoPorcientoFinanciero = precioFob * 1 / 100;

                        decimal? costoTotal = interCompany + unoPorcientoFinanciero + montoInternacion + precioFob;

                        // TIPO DE COTIZACIÓN DIRECTA:
                        if (cotizacion.TipoCotizacionId == 1)
                        {
                            costoTotal = unoPorcientoFinanciero + montoInternacion + precioFob;
                        }

                        decimal? costoFinalTotal = costoTotal * material.Cantidad;

                        decimal? totalSale = material.TotalNeto;

                        decimal? margen = 100 * (totalSale - costoFinalTotal) / totalSale;

                        material.PrecioFob = precioFob;
                        material.Intercompany = interCompany;
                        material.MontoInternacion = montoInternacion;
                        material.UnoPorcientoFinanciero = unoPorcientoFinanciero;
                        material.CostoTotal = costoTotal;
                        material.TotalCompra = material.TotalCompra;
                        material.CostoFinalTotal = costoFinalTotal;
                        material.Margen = margen;

                        materialesCotizacion.Add(material);
                    }
                }

                cotizacion.MaterialesCotizacion = materialesCotizacion;

                _context.Add(cotizacion);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }

            ViewData["CanalId"] = new SelectList(_context.Canales, "CanalId", nameof(Canal.RazonSocial), cotizacion.CanalId);
            ViewData["ContactoCanalId"] = new SelectList(_context.ContactosCanales.Where(c => c.CanalId == cotizacion.CanalId), "ContactoCanalId", nameof(ContactoCanal.Nombre), cotizacion.ContactoCanalId);
            ViewData["ClienteFinalId"] = new SelectList(_context.ClientesFinales, "ClienteFinalId", nameof(ClienteFinal.RazonSocial), cotizacion.ClienteFinalId);
            ViewData["ContactoClienteFinalId"] = new SelectList(_context.ContactosClientesFinales.Where(c => c.ClienteFinalId == cotizacion.ClienteFinalId), "ContactoClienteFinalId", nameof(ContactoClienteFinal.Nombre), cotizacion.ContactoClienteFinalId);
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre), cotizacion.FabricanteId);
            ViewData["QuoteId"] = new SelectList(_context.Quotes, "QuoteId", nameof(Quote.NumeroQuote), cotizacion.QuoteId);
            ViewData["TipoCompraId"] = new SelectList(_context.TiposCompra, "TipoCompraId", nameof(TipoCompra.Nombre), cotizacion.TipoCompraId);
            ViewData["TipoCotizacionId"] = new SelectList(_context.TiposCotizacion, "TipoCotizacionId", nameof(TipoCotizacion.Nombre), cotizacion.TipoCotizacionId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", nameof(Usuario.NombreUsuario), cotizacion.UsuarioId);
            return View(cotizacion);
        }

        // GET: Cotizaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cotizaciones == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizaciones.Where(c => c.CotizacionId == id).Include(c => c.MaterialesCotizacion).ThenInclude(m => m.Material).FirstOrDefaultAsync();

            var quote = await _context.Quotes.Where(q => q.QuoteId == cotizacion.QuoteId).FirstOrDefaultAsync();
            if (cotizacion == null || quote == null)
            {
                return NotFound();
            }
            ViewData["CanalId"] = new SelectList(_context.Canales, "CanalId", nameof(Canal.RazonSocial), cotizacion.CanalId);
            ViewData["ClienteFinalId"] = new SelectList(_context.ClientesFinales, "ClienteFinalId", nameof(ClienteFinal.RazonSocial), cotizacion.ClienteFinalId);
            ViewData["ContactoCanalId"] = new SelectList(_context.ContactosCanales.Where(c => c.CanalId == cotizacion.CanalId), "ContactoCanalId", nameof(ContactoCanal.Nombre), cotizacion.ContactoCanalId);
            ViewData["ContactoClienteFinalId"] = new SelectList(_context.ContactosClientesFinales.Where(c => c.ClienteFinalId == cotizacion.ClienteFinalId), "ContactoClienteFinalId", nameof(ContactoClienteFinal.Nombre), cotizacion.ContactoClienteFinalId);
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre), cotizacion.FabricanteId);
            ViewData["ContactoFabricanteId"] = new SelectList(_context.ContactosFabricantes.Where(f => f.FabricanteId == cotizacion.FabricanteId), "ContactoFabricanteId", nameof(ContactoFabricante.Nombre), quote.ContactoFabricanteId);
            ViewData["QuoteId"] = new SelectList(_context.Quotes, "QuoteId", nameof(Quote.NumeroQuote), cotizacion.QuoteId);
            ViewData["TipoCompraId"] = new SelectList(_context.TiposCompra, "TipoCompraId", nameof(TipoCompra.Nombre), cotizacion.TipoCompraId);
            ViewData["TipoCotizacionId"] = new SelectList(_context.TiposCotizacion, "TipoCotizacionId", nameof(TipoCotizacion.Nombre), cotizacion.TipoCotizacionId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", nameof(Usuario.NombreUsuario), cotizacion.UsuarioId);

            var listaMateriales = _context.Materiales.OrderBy(m => m.Sku).ToList();
            var selectListMateriales = new List<SelectListItem>();
            foreach (var material in listaMateriales)
            {
                var texto = material.Sku + " | " + material.Descripcion;

                var itemMaterial = new SelectListItem
                {
                    Text = texto,
                    Value = material.MaterialId.ToString()
                };

                selectListMateriales.Add(itemMaterial);
            }


            ViewData["Materiales"] = new SelectList(selectListMateriales, "Value", "Text");

            var materiales = new List<MaterialCotizacion>();
            foreach (var material in cotizacion.MaterialesCotizacion)
            {
                materiales.Add(material);
            }

            for (int i = 0; i < 100 - cotizacion.MaterialesCotizacion.Count; i++)
            {
                var material = new MaterialCotizacion
                {
                    FechaInicio = DateTime.Now,
                    FechaTermino = DateTime.Now.AddDays(30),
                    Cantidad = 0,
                    ImpuestoDuty = 0,
                    PrecioUnitario = 0,
                    DescuentoPorcentaje = 0
                };
                materiales.Add(material);
            }
            cotizacion.MaterialesCotizacion = materiales;

            var model = new CotizacionCreateViewModel
            {
                Cotizacion = cotizacion,
                Quote = quote
            };

            return View(model);
        }

        // POST: Cotizaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [RequestFormLimits(ValueCountLimit = int.MaxValue)]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cotizacion cotizacion, Quote quote)
        {
            if (cotizacion != null && quote != null)
            {
                try
                {
                    _context.Update(quote);

                    cotizacion.QuoteId = quote.QuoteId;
                    cotizacion.FabricanteId = quote.FabricanteId;

                    var materialesCotizacion = new List<MaterialCotizacion>();

                    foreach (var material in cotizacion.MaterialesCotizacion)
                    {
                        if (material.TotalNeto != null && material.TotalNeto > 0)
                        {
                            material.CotizacionId = cotizacion.CotizacionId;

                            decimal? precioUnitario = material.PrecioUnitario;
                            decimal? descuento = material.DescuentoPorcentaje;

                            decimal precioFob = 0;
                            decimal.TryParse((precioUnitario * (1 - descuento / 100))?.ToString("N2"), out precioFob);

                            decimal? interCompany = precioFob * 2 / 1000;
                            if (material.TipoMaterial == "HW")
                            {
                                interCompany = precioFob * 8 / 1000;
                            }

                            decimal? montoInternacion = precioFob * material.ImpuestoDuty * 1 / 100;
                            if (material.TipoMaterial == "SW")
                            {
                                montoInternacion = 0;
                            }

                            decimal? unoPorcientoFinanciero = precioFob * 1 / 100;
                            decimal? costoTotal = interCompany + unoPorcientoFinanciero + montoInternacion + precioFob;

                            // TIPO DE COTIZACIÓN DIRECTA:
                            if (cotizacion.TipoCotizacionId == 1)
                            {
                                costoTotal = unoPorcientoFinanciero + montoInternacion + precioFob;
                            }

                            decimal? costoFinalTotal = costoTotal * material.Cantidad;

                            decimal? totalSale = material.TotalNeto;

                            decimal? margen = 100 * (totalSale - costoFinalTotal) / totalSale;

                            material.PrecioFob = precioFob;
                            material.Intercompany = interCompany;
                            material.MontoInternacion = montoInternacion;
                            material.UnoPorcientoFinanciero = unoPorcientoFinanciero;
                            material.CostoTotal = costoTotal;
                            material.TotalCompra = material.TotalCompra;
                            material.CostoFinalTotal = costoFinalTotal;
                            material.Margen = margen;

                            materialesCotizacion.Add(material);
                        }
                    }
                    cotizacion.MaterialesCotizacion = materialesCotizacion;

                    _context.Update(cotizacion);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotizacionExists(cotizacion.CotizacionId) || !QuoteExists(quote.QuoteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["CanalId"] = new SelectList(_context.Canales, "CanalId", nameof(Canal.RazonSocial), cotizacion.CanalId);
                ViewData["ClienteFinalId"] = new SelectList(_context.ClientesFinales, "ClienteFinalId", nameof(ClienteFinal.RazonSocial), cotizacion.ClienteFinalId);
                ViewData["ContactoCanalId"] = new SelectList(_context.ContactosCanales.Where(c => c.CanalId == cotizacion.CanalId), "ContactoCanalId", nameof(ContactoCanal.Nombre), cotizacion.ContactoCanalId);
                ViewData["ContactoClienteFinalId"] = new SelectList(_context.ContactosClientesFinales.Where(c => c.ClienteFinalId == cotizacion.ClienteFinalId), "ContactoClienteFinalId", nameof(ContactoClienteFinal.Nombre), cotizacion.ContactoClienteFinalId);
                ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre), cotizacion.FabricanteId);
                ViewData["ContactoFabricanteId"] = new SelectList(_context.ContactosFabricantes.Where(f => f.FabricanteId == cotizacion.FabricanteId), "ContactoFabricanteId", nameof(ContactoFabricante.Nombre), quote.ContactoFabricanteId);
                ViewData["QuoteId"] = new SelectList(_context.Quotes, "QuoteId", nameof(Quote.NumeroQuote), cotizacion.QuoteId);
                ViewData["TipoCompraId"] = new SelectList(_context.TiposCompra, "TipoCompraId", nameof(TipoCompra.Nombre), cotizacion.TipoCompraId);
                ViewData["TipoCotizacionId"] = new SelectList(_context.TiposCotizacion, "TipoCotizacionId", nameof(TipoCotizacion.Nombre), cotizacion.TipoCotizacionId);
                ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", nameof(Usuario.NombreUsuario), cotizacion.UsuarioId);

                var listaMateriales = _context.Materiales.OrderBy(m => m.Sku).ToList();
                var selectListMateriales = new List<SelectListItem>();
                foreach (var material in listaMateriales)
                {
                    var texto = material.Sku + " | " + material.Descripcion;

                    var itemMaterial = new SelectListItem
                    {
                        Text = texto,
                        Value = material.MaterialId.ToString()
                    };

                    selectListMateriales.Add(itemMaterial);
                }


                ViewData["Materiales"] = new SelectList(selectListMateriales, "Value", "Text");

                var materiales = new List<MaterialCotizacion>();
                foreach (var material in cotizacion.MaterialesCotizacion)
                {
                    materiales.Add(material);
                }

                for (int i = 0; i < 100 - cotizacion.MaterialesCotizacion.Count; i++)
                {
                    var material = new MaterialCotizacion
                    {
                        FechaInicio = DateTime.Now,
                        FechaTermino = DateTime.Now.AddDays(30),
                        Cantidad = 0,
                        ImpuestoDuty = 0,
                        PrecioUnitario = 0,
                        DescuentoPorcentaje = 0
                    };
                    materiales.Add(material);
                }
                cotizacion.MaterialesCotizacion = materiales;

                var model = new CotizacionCreateViewModel
                {
                    Cotizacion = cotizacion,
                    Quote = quote
                };

                return View(model);
            }
        }

        // GET: Cotizaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cotizaciones == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizaciones
                .Include(c => c.Canal)
                .Include(c => c.ClienteFinal)
                .Include(c => c.ContactoCanal)
                .Include(c => c.ContactoClienteFinal)
                .Include(c => c.Fabricante)
                .Include(c => c.Quote)
                .Include(c => c.TipoCompra)
                .Include(c => c.TipoCotizacion)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.CotizacionId == id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        // POST: Cotizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cotizaciones == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cotizaciones'  is null.");
            }
            var cotizacion = await _context.Cotizaciones.FindAsync(id);
            if (cotizacion != null)
            {
                var materialesDelete = _context.MaterialesCotizacion.Where(m => m.CotizacionId == id).ToList();
                foreach (var materialDelete in materialesDelete)
                {
                    _context.Remove(materialDelete);
                }
                _context.Cotizaciones.Remove(cotizacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CotizacionExists(int id)
        {
            return (_context.Cotizaciones?.Any(e => e.CotizacionId == id)).GetValueOrDefault();
        }

        private bool QuoteExists(int id)
        {
            return (_context.Quotes?.Any(e => e.QuoteId == id)).GetValueOrDefault();
        }
    }
}
