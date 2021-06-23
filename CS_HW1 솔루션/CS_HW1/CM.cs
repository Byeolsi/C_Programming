using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks.Sources;

namespace CS_HW1
{
    class CM
    {
        /* 컴퓨터의 총 갯수와 종류 별 마다의 갯수, 그리고 총 지불된 요금 */
        private uint Ncomp, Nuser, Nnet, Nnote, Ndesk, totalCost = 0;

        /* 컴퓨터와 유저 클래스 */
        private Computer[] arrComp;
        private User[] arrUser;

        /* Computer Manager 클래스 생성자 */
        public CM(uint Ncomp, uint Nuser, uint Nnet, uint Nnote, uint Ndesk)
        {
            this.Ncomp = Ncomp;
            this.Nuser = Nuser;
            this.Nnet = Nnet;
            this.Nnote = Nnote;
            this.Ndesk = Ndesk;
        }

        /* 클래스 메모리 할당 */

        // initComp() 메소드
        /*
            컴퓨터 클래스 메모리 할당. Netbook, Notebook, Desktop 의 각각 갯수에 따라 클래스 형태로 메모리를 할당하고,
            암시적 변환을 통해 이를 부모 클래스인 Computer 클래스 배열에 삽입.
        */
        public void initComp()
        {
            uint startIndex, endIndex, Id = 1, subId;

            arrComp = new Computer[Ncomp];                  // 입력 받은 컴퓨터의 총 갯수만큼 Computer 클래스 배열 메모리 할당.

            subId = 1;                                      // NetId, NoteId, DeskId
            startIndex = 0;                                 // 0 ~ Nnet. 즉, Nnet 의 갯수만큼.
            endIndex = Nnet;
            for (uint i = startIndex; i < endIndex; i++) 
            {
                arrComp[i] = new Netbook(0, Id, subId);
                Id++;
                subId++;
            }

            subId = 1;
            startIndex += Nnet;                             // Nnet ~ (Nnet + Nnote). 즉, Nnote 의 갯수만큼.
            endIndex += Nnote;
            for (uint i = startIndex; i < endIndex; i++)
            {
                arrComp[i] = new Notebook(1, Id, subId);
                Id++;
                subId++;
            }

            subId = 1;
            startIndex += Nnote;                            // (Nnet + Nnote) ~ (Nnet + Nnote + Ndesk). 즉, Ndesk 의 갯수만큼.
            endIndex += Ndesk;
            for (uint i = startIndex; i < endIndex; i++)
            {
                arrComp[i] = new Desktop(2, Id, subId);
                Id++;
                subId++;
            }
        }

        // initUser(StreamReader) 메소드
        /*
            유저 클래스 메모리 할당. 읽어들인 문자열을 통해, 유저의 타입을 결정하고, 타입에 따라 클래스를 할당한다.
            할당된 클래스들은 암시적 변환을 통해 부모 클래스인 Computer 클래스 배열에 삽입.
        */
        public void initUser(StreamReader sr)
        {
            uint Id = 1, workerId = 1, studId = 1, gamerId = 1;
            string tmpreadline;
            string[] splitLine = new string[2];

            arrUser = new User[Nuser];

            for (int i = 0; i < Nuser; i++)
            {
                tmpreadline = sr.ReadLine();
                splitLine = tmpreadline.Split(" ", StringSplitOptions.None);

                // 첫 문자열(splitLine[0]) 에 따라 유저의 타입이 결정됨. 두번째 문자열(splitLine[1]) 은 유저의 이름으로 들어감.
                switch (splitLine[0])
                {
                    case "Worker":
                        arrUser[i] = new Workers(0, Id, workerId, splitLine[1]);
                        Id++;
                        workerId++;
                        break;
                    case "Student":
                        arrUser[i] = new Students(1, Id, studId, splitLine[1]);
                        Id++;
                        studId++;
                        break;
                    case "Gamer":
                        arrUser[i] = new Gamers(2, Id, gamerId, splitLine[1]);
                        Id++;
                        gamerId++;
                        break;
                    default:
                        Console.WriteLine("입력된 정보를 확인할 수 없습니다.");
                        Environment.Exit(1);
                        break;
                }
            }
        }

        /* 명령어 메소드 */

        // assignComp(SteramWriter, uint(Id), uint(dr)) 메소드
        // 유저에게 컴퓨터 할당. 유저에게 맞는 최소 조건의 컴퓨터를 우선적으로 찾고, 이를 유저에게 할당.
        public void assignComp(StreamWriter sw, uint Id, uint dr)
        {
            uint arrN = Id - 1;
            uint i = 0;

            // 예외 처리. 유저가 이미 컴퓨터를 빌린 상태일 수 있음.
            if (arrUser[arrN].Rent)
            {
                Console.WriteLine("이 사용자는 이미 컴퓨터를 사용하고 있습니다.");
                sw.WriteLine("The user is already assigned a computer!");
                return;
            }
            // 유저의 타입에 따라 조건에 맞는 컴퓨터의 위치부터 검색을 시작함.
            // ex ) 유저 타입이 Gamers 라면 Nnet + Note 부터 검색을 시작함으로써, arrComp 배열 에서 Desktop 클래스가 삽입되어 있는 인덱스부터 순서대로 탐색함.
            switch (arrUser[arrN].UserType)
            {
                case (byte)0:
                    i = 0;
                    break;
                case (byte)1:
                    i = Nnet;
                    break;
                case (byte)2:
                    i = Nnet + Nnote;
                    break;
                default:
                    Console.WriteLine("올바르지 않은 데이터가 발견되었습니다.");
                    return;
            }

            // 이용 가능한 컴퓨터를 탐색.
            while (i < Ncomp && !arrComp[i].Avail)
            {
                i++;
            }

            // i 가 Ncomp 와 같아진다면, 이용 가능한 컴퓨터를 찾지 못한 것.
            if (i >= Ncomp)
            {
                Console.WriteLine("이용 가능한 컴퓨터가 없습니다.");
                sw.WriteLine("Can not found an available computer!");
            }
            // 그렇지 않다면, 이용 가능한 컴퓨터를 찾은 것. 요구 일수, 남은 일수, 사용 일수 등을 초기화.
            else
            {
                arrComp[i].DL = dr;
                arrComp[i].DR = dr;
                arrComp[i].DU = 0;
                arrComp[i].RentUserId = arrUser[arrN].UserId;
                arrComp[i].Avail = false;

                arrUser[arrN].RentedCom = arrComp[i].ComId;
                arrUser[arrN].Rent = true;
                sw.WriteLine("Computer #{0} has been assigned to User #{1}", arrComp[i].ComId, arrUser[arrN].UserId);
            }
        }

        // returnComp(StreamWriter, uint(Id)) 메소드
        // 유저가 컴퓨터를 반환. 반환하고자 하는 컴퓨터의 사용 일수(DU)를 확인하고, 그에 맞는 요금을 totalCost 에 더함.
        public void returnComp(StreamWriter sw, uint Id)
        {
            uint cost = 0;

            Computer refCom;
            User refUser = arrUser[Id-1];                       // 유저 배열의 인덱스는 유저 ID - 1

            if (refUser.Rent)
            {
                refCom = arrComp[(int)(refUser.RentedCom - 1)]; // 컴퓨터 배열의 인덱스는 유저가 빌린 컴퓨터의 ID - 1
                
                // 컴퓨터 타입에 따라 cost 계산
                switch (refCom.ComType)
                {
                    case (byte)0:
                        cost = refCom.DU * (uint)7000;
                        totalCost += cost;
                        break;
                    case (byte)1:
                        cost = refCom.DU * (uint)10000;
                        totalCost += cost;
                        break;
                    case (byte)2:
                        cost = refCom.DU * (uint)13000;
                        totalCost += cost;
                        break;
                    default:
                        Console.WriteLine("올바르지 않은 데이터가 발견되었습니다.");
                        return;
                }
                sw.WriteLine("User #{0} has returned Computer #{1} and paid {2} won.", refUser.UserId, refCom.ComId, cost);

                // 컴퓨터의 요구 일수, 남은 일수, 사용 일수를 default 값으로 다시 초기화.
                refCom.DL = 0;
                refCom.DR = 0;
                refCom.DU = 0;
                refCom.Avail = true;

                refUser.Rent = false;
            }
            else
            {
                Console.WriteLine("해당 유저는 컴퓨터를 빌리고 있지 않습니다.");
                sw.WriteLine("The user hasn't rented any computers!");
            }
        }

        // printStat(StreanWriter) 메소드
        /*
            현재 상황 기록. for문을 이용하여 전체 컴퓨터(arrComp)와 전체 유저(arrUser)의 타입을 확인한다.
            그 타입에 맞게 명시적 변환을 이용하여 부모 클래스로부터 자식 클래스로 변환받고 모든 정보를 출력한다.
        */
        public void printStat(StreamWriter sw)
        {
            Netbook refNet;
            Notebook refNote;
            Desktop refDesk;

            Workers refWorker;
            Students refStud;
            Gamers refGamer;

            sw.WriteLine("Total Cost: {0}", totalCost);

            // Computer List 출력.
            sw.WriteLine("Computer List:");
            for (int i = 0; i < Ncomp; i++)
            {
                sw.Write("({0}) type: ", i+1);
                // 컴퓨터 타입에 따라 다르게 출력. NetId, NoteId, DeskId 가 각자 다르고, 제공하는 서비스가 다르기 때문에.
                switch (arrComp[i].ComType)
                {
                    case (byte)0:
                        refNet = arrComp[i] as Netbook;
                        sw.Write($"Netbook, ComId: {refNet.ComId}, NetId: {refNet.NetId}, Used for: internet, Avail: ");
                        // 이용 가능 상태(Avail) 에 따라 다르게 출력.
                        if (refNet.Avail)
                        {
                            sw.WriteLine("Y");
                        }
                        else
                        {
                            sw.WriteLine($"N (UserId: {refNet.RentUserId}, DR: {refNet.DR}, DL: {refNet.DL}, DU: {refNet.DU})");
                        }
                        break;
                    case (byte)1:
                        refNote = arrComp[i] as Notebook;
                        sw.Write($"Notebook, ComId: {refNote.ComId}, NoteId: {refNote.NoteId}, Used for: internet, scientific, Avail: ");
                        if (refNote.Avail)
                        {
                            sw.WriteLine("Y");
                        }
                        else
                        {
                            sw.WriteLine($"N (UserId: {refNote.RentUserId}, DR: {refNote.DR}, DL: {refNote.DL}, DU: {refNote.DU})");
                        }
                        break;
                    case (byte)2:
                        refDesk = arrComp[i] as Desktop;
                        sw.Write($"Desktop, ComId: {refDesk.ComId}, DeskId: {refDesk.DeskId}, Used for: internet, scientific, game, Avail: ");
                        if (refDesk.Avail)
                        {
                            sw.WriteLine("Y");
                        }
                        else
                        {
                            sw.WriteLine($"N (UserId: {refDesk.RentUserId}, DR: {refDesk.DR}, DL: {refDesk.DL}, DU: {refDesk.DU})");
                        }
                        break;
                    default:
                        sw.WriteLine("Unknown");
                        break;
                }
            }

            // User List 출력.
            sw.WriteLine("User List:");
            for (int i = 0; i < Nuser; i++)
            {
                sw.Write("({0}) type: ", i+1);
                // 유저 타입에 따라 다르게 출력. WorkerId, StudId, GamerId 가 각자 다르고, 이용하고자 하는 서비스가 다르기 때문에.
                switch (arrUser[i].UserType)
                {
                    case (byte)0:
                        refWorker = arrUser[i] as Workers;
                        sw.Write($"OfficeWorkers, Name: {refWorker.UserName}, UserId: {refWorker.UserId}, WorkerId: {refWorker.WorkerId}, Used for: internet, Rent: ");
                        // 대여 상태(Rent) 에 따라 다르게 출력.
                        if (refWorker.Rent)
                        {
                            sw.WriteLine($"Y (RentCompId: {refWorker.RentedCom})");
                        }
                        else
                        {
                            sw.WriteLine("N");
                        }
                        break;
                    case (byte)1:
                        refStud = arrUser[i] as Students;
                        sw.Write($"Students, Name: {refStud.UserName}, UserId: {refStud.UserId}, StudId: {refStud.StudId}, Used for: internet, scientific, Rent: ");
                        if (refStud.Rent)
                        {
                            sw.WriteLine($"Y (RentCompId: {refStud.RentedCom})");
                        }
                        else
                        {
                            sw.WriteLine("N");
                        }
                        break;
                    case (byte)2:
                        refGamer = arrUser[i] as Gamers;
                        sw.Write($"Gamers, Name: {refGamer.UserName}, UserId: {refGamer.UserId}, GamerId: {refGamer.GamerId}, Used for: internet, game, Rent: ");
                        if (refGamer.Rent)
                        {
                            sw.WriteLine($"Y (RentCompId: {refGamer.RentedCom})");
                        }
                        else
                        {
                            sw.WriteLine("N");
                        }
                        break;
                    default:
                        sw.WriteLine("Unknown");
                        break;
                }
            }
        }

        // aDayGose(StreamWriter)
        // 하루 경과. 전체 컴퓨터(arrComp)를 모두 확인하여 arrComp.Avail 이 False 일 때, 남은 날짜(DL)를 하루 줄이고, 사용 날짜(DU)를 하루 늘린다. 만약, 남은 날짜(DL)가 0 이라면, 강제적으로 컴퓨터를 반환받는다.
        public void aDayGose(StreamWriter sw)
        {
            sw.WriteLine("It has passed one day...");
            for (int i = 0; i < Ncomp; i++)
            {
                // Avail 이 false 일 경우, 대여된 컴퓨터 임을 의미하므로,
                if (!arrComp[i].Avail)
                {
                    // 남은 일수(DL) 와 사용 일수(DU) 를 갱신.
                    arrComp[i].DL--;
                    arrComp[i].DU++;
                    // 갱신 후, 남은 일수(DL) 가 0 이라면 returnComp 메소드 실행.
                    if (arrComp[i].DL == 0)
                    {
                        sw.Write("Time for Computer #{0} has expired. ", arrComp[i].ComId);
                        returnComp(sw, arrComp[i].RentUserId);
                    }
                }
            }
        }
        //
    }
}
