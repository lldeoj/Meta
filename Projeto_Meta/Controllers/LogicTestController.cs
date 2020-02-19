using Projeto_Meta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Meta.Controllers
{
    public class LogicTestController : Controller
    {
        // GET: LogicTest
        public ActionResult Index()
        {
            return View();
        }

        #region Questao_01
        public ActionResult Questao_01()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Questao_01(FormCollection collection)
        {
            char[] split = { ';', ',' };
            Modelo_01 q1 = new Modelo_01();
            q1.valores = collection["valores"];
            q1.alvo = int.Parse(collection["alvo"]);
            string[] vet = q1.valores.Split(split, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < vet.Count(); i++)
            {
                for (int j = i; j < vet.Count(); j++)
                {
                    if (i != j && int.Parse(vet[i]) + int.Parse(vet[j]) == q1.alvo)
                    {
                        q1.resultado = string.Format("[{0}, {1}]", i, j);
                        return View(q1);
                    }
                }

            }


            return View(q1);
        }

        #endregion

        #region Questão_02
        public ActionResult Questao_02()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Questao_02(FormCollection collection)
        {
            string ab = "{}[]()";
            Stack<string> pilha = new Stack<string>();
            Modelo_02 q2 = new Modelo_02();
            q2.valores = collection["valores"];

            //se a quantidade de caracteres for impar, quer dizer que está desbalanceado
            q2.resultado = q2.valores.Length % 2 == 0 ? "SIM" : "NÃO";

            //se desbalanceado não precisa nem verificar.
            if (q2.valores.Length % 2 == 0)
            {
                foreach (var item in q2.valores.ToArray<char>())
                {
                    if (ab.IndexOf(item) % 2 == 0)
                    {
                        pilha.Push(item.ToString());
                    }
                    else
                    {
                        if (ab.IndexOf(pilha.Pop()) + 1 != ab.IndexOf(item))
                            q2.resultado = "NÃO";
                    }
                }
            }


            return View(q2);
        }

        #endregion


        public ActionResult Questao_03()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Questao_03(FormCollection collection)
        {
            char[] split = { ';', ',' };
            Modelo_02 q3 = new Modelo_02();
            q3.valores = collection["valores"];
            string[] vet = q3.valores.Split(split, StringSplitOptions.RemoveEmptyEntries);

            int LucroMax = 0;
            int DiaCompra = 0;
            int DiaVenda = 0;


            for (int i = 0; i < vet.Count(); i++)
            {
                for (int j = i; j < vet.Count(); j++)
                {
                    if (i != j && int.Parse(vet[j]) - int.Parse(vet[i]) > LucroMax)
                    {
                        DiaCompra = i;
                        DiaVenda = j;
                        LucroMax = int.Parse(vet[j]) - int.Parse(vet[i]);
                    }
                }

            }

            q3.resultado = DiaCompra == DiaVenda ?
                                        "0 (Nesse caso nenhuma transação deve ser feita, lucro máximo igual a 0)" :
                                        string.Format("{0} (Comprou no dia {1} (preço igual a {2}) " +
                                         "e vendeu no dia {3} (preço igual a {4}), " +
                                         "lucro foi de {4} – {2} = {0}", LucroMax.ToString(),
                                                                        DiaCompra.ToString(),
                                                                        vet[DiaCompra].ToString(),
                                                                        DiaVenda.ToString(),
                                                                        vet[DiaVenda].ToString());

            return View(q3);
        }


        public ActionResult Questao_04()
        {
            return View();
        }

        // GET: LogicTest/Details/5
        [HttpPost]
        public ActionResult Questao_04(FormCollection collection)
        {
            char[] split = { ';', ',' };
            Modelo_02 q1 = new Modelo_02();
            q1.valores = collection["valores"];

            string[] vet = q1.valores.Split(split, StringSplitOptions.RemoveEmptyEntries);
            string[] aux = new string[vet.Length];

            int ini = 0;
            int fim = 0;
            int qtd = 0;
            int tot = 0;

            for (int i = 0; i < vet.Count(); i++)
            {
                aux = new string[vet.Length - i - 1];
                Array.Copy(vet, i + 1, aux, 0, vet.Length - i - 1);

                if (int.Parse(vet[i]) > 0 && int.Parse(vet[i]) > ini)
                {
                    ini = aux.Count(x => int.Parse(x) >= int.Parse(vet[i])) > 0 ? int.Parse(vet[i]) : ini;
                    tot += qtd;
                    qtd = 0;
                }
                else
                {
                    qtd += aux.Count(x => int.Parse(x) >= int.Parse(vet[i])) > 0 ? ini - int.Parse(vet[i]) : 0;
                }
            }

            tot += qtd;

            q1.resultado = tot.ToString();


            return View(q1);
        }

    }
}
