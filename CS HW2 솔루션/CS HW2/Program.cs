using System;
using System.IO;

namespace CS_HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            int placeId, vehicleId, priority, numWaitingPlaces;
            string tmpLine, order, address;
            string[] splitLine = new string[5];

            DeliveryVehicleManager VM;

            StreamWriter sw = new StreamWriter(new FileStream("OUTPUT.txt", FileMode.Create));
            StreamReader sr = new StreamReader(new FileStream("INPUT.txt", FileMode.Open));

            tmpLine = sr.ReadLine();
            // 잘못된 파일인지 확인.
            if (tmpLine != null)
            {
                if ('0' <= tmpLine[0] && tmpLine[0] <= '9')
                {
                    numWaitingPlaces = int.Parse(tmpLine);

                    VM = new DeliveryVehicleManager(numWaitingPlaces);
                }
                else
                {
                    Console.WriteLine("잘못된 입력 파일입니다!");

                    return;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력 파일입니다!");

                return;
            }

            // 명령어로 "Quit" 이 입력될 때까지 반복.
            do
            {
                // 더 이상 읽어 들일 문자가 없는 경우, break.
                if (sr.Peek() < 0)
                {
                    Console.WriteLine("파일에 더 이상 데이터가 존재하지 않습니다.");

                    break;
                }

                tmpLine = sr.ReadLine();
                splitLine = tmpLine.Split(" ", StringSplitOptions.None);

                order = splitLine[0];

                // 명령어에 따라 다르게 수행.
                switch (order)
                {
                    case "ReadyIn":
                        // 앞에 문자를 제거한 후에 int 형으로 변환.
                        placeId = int.Parse(splitLine[1].Remove(0, 1));
                        vehicleId = int.Parse(splitLine[2]);
                        address = splitLine[3];
                        priority = int.Parse(splitLine[4].Remove(0, 1));

                        VM.Readyin(placeId, vehicleId, address, priority);

                        sw.WriteLine($"Vehicle {vehicleId} assigned to WaitPlace #{placeId}.");
                        
                        break;

                    case "Ready":
                        vehicleId = int.Parse(splitLine[1]);
                        address = splitLine[2];
                        priority = int.Parse(splitLine[3].Remove(0, 1));

                        // Ready 메소드의 반환 값으로 대기 장소 ID 를 반환.
                        placeId = VM.Ready(vehicleId, address, priority);

                        // 반환 받은 값을 이용하여 파일에 쓴다.
                        sw.WriteLine($"Vehicle {vehicleId} assigned to WaitPlace #{placeId}.");

                        break;

                    case "Status":
                        VM.Status(sw);

                        break;

                    case "Cancel":
                        vehicleId = int.Parse(splitLine[1]);

                        VM.Cancel(vehicleId);

                        sw.WriteLine($"Cancelation of Vehicle {vehicleId} completed.");

                        break;

                    case "Deliver":
                        placeId = int.Parse(splitLine[1].Remove(0, 1));

                        vehicleId = VM.Deliver(placeId);

                        sw.WriteLine($"Vehicle {vehicleId} used to deliver.");

                        break;

                    case "Clear":
                        placeId = int.Parse(splitLine[1].Remove(0, 1));

                        VM.Clear(placeId);

                        sw.WriteLine($"WaitPlace #{placeId} cleared.");

                        break;

                    default:
                        if (order != "Quit")
                            Console.WriteLine("인식할 수 없는 명령어입니다.");

                        break;

                }

            } while (order != "Quit");

            sr.Close();
            sw.Close();
        }
    }
}
