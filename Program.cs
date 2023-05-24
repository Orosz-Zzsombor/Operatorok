
using ConsoleApp4;
using System.Threading.Channels;


List<Operatorok> operak = new List<Operatorok>();
File.ReadAllLines("kifejezesek.txt").ToList().ForEach(x=> operak.Add( new Operatorok(x)));
Console.WriteLine($"2. feladat? Kifejezések száma: {operak.Count()}");
Console.WriteLine($"3. feladat: Kifejezések maradékos osztással: {operak.Where(x => x.Muvelet == "mod").Count()}");
if (operak.Exists(x => x.OperandusA % 10 == 0 && x.OperndusB % 10 == 0))
{
    Console.WriteLine($"4. feladat: Van ilyen kifejezés");
}
else
{
    Console.WriteLine($"4. feladat: Nincs ilyen kifejezés");
}

List<string> jelek = new List<string>()
{
    "+","-","*","/","div","mod"
};


    operak.Where(x=> jelek.Contains(x.Muvelet)).GroupBy(x => x.Muvelet).ToList().ForEach(cs => Console.WriteLine($"\r{cs.Key} -> {cs.Count()} db"));

string Meghatarozas(List<string> elfogadottJelek, Operatorok gabor){

    if (!elfogadottJelek.Contains(gabor.Muvelet))
      {
         return "Hibás operátor";
      }
    try
    {
        if (gabor.Muvelet == "+") { return Convert.ToString(gabor.OperandusA + gabor.OperndusB); }
        else if (gabor.Muvelet == "-") { return Convert.ToString(gabor.OperandusA - gabor.OperndusB); }
        else if (gabor.Muvelet == "*") { return Convert.ToString(gabor.OperandusA * gabor.OperndusB); }
        else if (gabor.Muvelet == "/") { return Convert.ToString(gabor.OperandusA / Convert.ToDouble(gabor.OperndusB)); }
        else if (gabor.Muvelet == "div") { return Convert.ToString(gabor.OperandusA / gabor.OperndusB); }
        else if (gabor.Muvelet == "mod") { return Convert.ToString(gabor.OperandusA % gabor.OperndusB); }
    }
    catch (Exception)
    {
        return "Egyéb hiba";
    }
    return "";
}

Console.WriteLine($"7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
string megadott = Console.ReadLine();

while (megadott!="Vége")
{

    Console.WriteLine(Meghatarozas(jelek, new Operatorok(megadott)));
    Console.WriteLine($"7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
    megadott = Console.ReadLine();
}

List<string> megoldott = new List<string>();

operak.ForEach(elem => megoldott.Add($"{Convert.ToString(elem.OperandusA)+elem.Muvelet+Convert.ToString(elem.OperndusB)} = {Meghatarozas(jelek,elem)}"));

File.WriteAllLines("eredmenyek.txt", megoldott);
Console.WriteLine("8. feladat: eredmenyek.txt");