using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace CS_HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            char command;                           // 명령어
            uint Ncomp, Nnet, Nnote, Ndesk, Nuser;  // 컴퓨터 수, 넷북 수, 노트북 수, 데스크탑 수, 유저 수
            uint userId, rentDay;                   // 유저 ID, 대여 요청 날짜
            string tmpreadline;                     // 텍스트 파일로부터 임시적으로 한 줄 읽어오기 위한 문자열
            string[] splitLine = new string[3];     // 문자열을 나누기 위한 문자열 배열

            CM computerManager;                     // Computer Manager

            StreamReader sr = new StreamReader("input.txt");
            StreamWriter sw = new StreamWriter("output.txt");

            // 컴퓨터 수, 넷북 수, 노트북 수, 데스크탑 수, 유저 수 입력받음.
            if (sr.Peek() >= 0)
            {
                tmpreadline = sr.ReadLine();
                Ncomp = uint.Parse(tmpreadline);

                tmpreadline = sr.ReadLine();
                splitLine = tmpreadline.Split(" ", StringSplitOptions.None);
                Nnote = uint.Parse(splitLine[0]);
                Ndesk = uint.Parse(splitLine[1]);
                Nnet = uint.Parse(splitLine[2]);

                tmpreadline = sr.ReadLine();
                Nuser = uint.Parse(tmpreadline);

                // 입력이 잘못됨.
                if (Ncomp != Nnet + Nnote + Ndesk)
                {
                    Console.WriteLine("입력된 정보를 확인할 수 없습니다.");
                    goto QUIT;
                }

                computerManager = new CM(Ncomp, Nuser, Nnet, Nnote, Ndesk);
                // 초기화 메소드 실행.
                computerManager.initComp();
                computerManager.initUser(sr);
            }
            else
            {
                Console.WriteLine("입력된 정보가 존재하지 않습니다.");
                goto QUIT;
            }

            try
            {
                while (sr.Peek() >= 0)              // 입력 파일에 더 이상 읽을 문자가 없을 때 까지 실행 
                {
                    tmpreadline = sr.ReadLine();    // 입력파일에 한 줄의 문자열을 읽어와 string 변수에 tmpreadline 할당
                    // 첫 글자가 Q, T, S 일 때, 추가적인 입력이 필요하지 않으므로,
                    if (tmpreadline.StartsWith("Q") || tmpreadline.StartsWith("T") || tmpreadline.StartsWith("S"))
                    {
                        splitLine[0] = tmpreadline;
                    }
                    // 첫 글자가 A, R 일 때, 추가적인 입력이 필요하므로,
                    else if (tmpreadline.StartsWith("A") || tmpreadline.StartsWith("R"))
                    {
                        splitLine = tmpreadline.Split(" ", StringSplitOptions.None);
                    }
                    // 예외 처리.
                    else
                    {
                        Console.WriteLine("입력된 정보를 확일한 수 없습니다.");
                        continue;
                    }

                    // 명령어 변수에 변환하여 저장.
                    command = char.Parse(splitLine[0]);
                    // 명령어에 따라 메소드를 실행.
                    switch (command)
                    {
                        case 'Q':
                            goto QUIT;
                        case 'A':
                            userId = uint.Parse(splitLine[1]);
                            rentDay = uint.Parse(splitLine[2]);

                            computerManager.assignComp(sw, userId, rentDay);

                            sw.WriteLine("============================================================");
                            break;
                        case 'R':
                            userId = uint.Parse(splitLine[1]);

                            computerManager.returnComp(sw, userId);

                            sw.WriteLine("============================================================");
                            break;
                        case 'T':
                            computerManager.aDayGose(sw);

                            sw.WriteLine("============================================================");
                            break;
                        case 'S':
                            computerManager.printStat(sw);

                            sw.WriteLine("============================================================");
                            break;
                        default:
                            Console.WriteLine("입력된 정보를 확인할 수 없습니다.");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

        QUIT:
            sr.Close();
            sw.Close(); // 닫아줘야 함.
        }
    }
}