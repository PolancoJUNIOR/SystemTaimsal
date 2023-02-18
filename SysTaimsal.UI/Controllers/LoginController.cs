//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using SysTaimsal.EL;
//using System.Net.Http.Headers;
//using System.Net.Http;
//using System.Security.Claims;
//using System.Text.Json;

//namespace SysTaimsal.UI.Controllers
//{
//    public class LoginController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//        // GET: UsuarioController/Create
//        [AllowAnonymous]
//        public async Task<IActionResult> Login(string ReturnUrl = null)
//        {
//            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//            ViewBag.Url = ReturnUrl;
//            ViewBag.Error = "";
//            return View();
//        }

//        // POST: UsuarioController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        [AllowAnonymous]
//        public async Task<IActionResult> Login(UserDev pUsuario, string pReturnUrl = null)
//        {
//            try
//            {
//                // Codigo agregar para consumir la Web API                  
//                var response = await httpClient.PostAsJsonAsync("Usuario/Login", pUsuario);
//                if (response.IsSuccessStatusCode)
//                {
//                    var token = await response.Content.ReadAsStringAsync();
//                    pUsuario.Top_Aux = 1;
//                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
//                    var responseBuscarUsuario = await httpClient.PostAsJsonAsync("Usuario/Buscar", pUsuario);
//                    if (responseBuscarUsuario.IsSuccessStatusCode)
//                    {
//                        var responseBody = await responseBuscarUsuario.Content.ReadAsStringAsync();
//                        var usuarios = JsonSerializer.Deserialize<List<UserDev>>(responseBody,
//                             new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
//                        if (usuarios != null && usuarios.Count > 0)
//                        {
//                            UserDev usuario = usuarios.FirstOrDefault();
//                            usuario.IdRol = await BuscarIncluirRolesAsync(new Rol { IdRol = usuario.IdRol });
//                            var claims = new[] { new Claim(
//                                ClaimTypes.Name, usuario.Login),
//                                new Claim(ClaimTypes.Role, usuario.Rol.Nombre),
//                                new Claim(ClaimTypes.Expired,token)
//                            };
//                            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
//                        }
//                    }
//                }
//                else
//                    throw new Exception("Credenciales incorrectas");
//                // ******************************************************************                
//                if (!string.IsNullOrWhiteSpace(pReturnUrl))
//                    return Redirect(pReturnUrl);
//                else
//                    return RedirectToAction("Index", "Home");
//            }
//            catch (Exception ex)
//            {
//                ViewBag.Url = pReturnUrl;
//                ViewBag.Error = ex.Message;
//                return View(new Usuario { Login = pUsuario.Login });
//            }
//        }
//    }
//}
