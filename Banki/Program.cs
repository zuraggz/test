using Banki;
Bank TBC = new Bank();
BankAccount zuragg = new BankAccount("zuragg",TBC);
BankAccount nuki = new BankAccount("nuki",TBC);

nuki.DisplayInfo();
zuragg.DisplayInfo();
Console.ReadLine();
nuki.Deposit(100);
TBC.Transfer(nuki.accountNumber, zuragg.accountNumber, 40);
nuki.DisplayInfo();
zuragg.DisplayInfo();
// js testing