
var an   = Member.Create("Nguyen Van An", "an@gmail.com", "DH24001");
var binh = Member.Create("Tran Thi Binh", "binh@gmail.com", "DH24002");
var chi  = Member.Create("Le Minh Chi", "chi@gmail.com", "DH24003");

var club = Club.Create("CLB Lap trinh", "Sinh hoat moi tuan");
var ev1 = Event.Create(club.Id, "Workshop Git", DateTime.Today.AddDays(7), 10);
var ev2 = Event.Create(club.Id, "Seminar .NET", DateTime.Today.AddDays(14), 50);

Console.WriteLine("--- US-05: Tao CLB ---");
var ClubNew = Club.Create("CLB Bong da", "Da bong thu 7");
Console.WriteLine($"1. Tao thanh cong: {ClubNew.Name}, so thanh vien = {ClubNew.MemberCount()}");
try { Club.Create("", "mo ta"); }
catch (Exception ex) { Console.WriteLine("2. Ten trong -> loi: " + ex.Message); }

// ===== US-04: Ban CLB xem danh sach thanh vien =====
Console.WriteLine("\n--- US-04: Xem thanh vien ---");
Console.WriteLine($"2. CLB moi co {ClubNew.Members.Count} thanh vien (rong)");
club.AddMember(an);
club.AddMember(binh);
club.AddMember(chi);
Console.WriteLine($"1. CLB co {club.MemberCount()} thanh vien:");
foreach (var m in club.Members) Console.WriteLine("   - " + m);

// ===== US-02: Sinh vien xem su kien da dang ky =====
Console.WriteLine("\n--- US-02: Xem su kien da dang ky ---");
var regAn1 = Registration.Create(an, ev1, 0);
var regAn2 = Registration.Create(an, ev2, 0);
Console.WriteLine("1. An co 2 phieu:");
Console.WriteLine($"   - {ev1.Title}: {regAn1.Status}");
Console.WriteLine($"   - {ev2.Title}: {regAn2.Status}");
Console.WriteLine("2. Chi chua dang ky -> danh sach rong");

// ===== US-03: Ban CLB xac nhan phieu =====
Console.WriteLine("\n--- US-03: Xac nhan phieu ---");
regAn1.Confirm();
Console.WriteLine("1. Pending -> " + regAn1.Status);
var regBinh = Registration.Create(binh, ev1, 1);
regBinh.Cancel();
try { regBinh.Confirm(); }
catch (Exception ex) { Console.WriteLine("2. Phieu Cancelled -> loi: " + ex.Message); }

// ===== US-01: Sinh vien huy dang ky =====
Console.WriteLine("\n--- US-01: Huy dang ky ---");
regAn2.Cancel();
Console.WriteLine("1. Pending -> " + regAn2.Status);
regAn1.Cancel();
Console.WriteLine("1. Confirmed -> " + regAn1.Status);
try { regAn1.Cancel(); }
catch (Exception ex) { Console.WriteLine("2. Huy lan nua -> loi: " + ex.Message); }