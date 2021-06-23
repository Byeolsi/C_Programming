using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CS_HW2
{
    // DeliveryVehicle 클래스
    class DeliveryVehicle
    {
        public int vehicleId { get; set; }
        public string destination { get; set; }
        public int priority { get; set; }

        // DeliveryVehicle 생성자
        // 필드를 모두 초기화.
        public DeliveryVehicle(int vehicleId, string address, int priority)
        {
            this.vehicleId = vehicleId;
            destination = address;
            this.priority = priority;
        }
    }

    // DeliveryVehicleManager 클래스
    class DeliveryVehicleManager
    {
        int numWaitingPlaces;
        ArrayList[] vehicleList;

        // DeliveryVehicleManager 생성자
        // 대기 장소 개수 멤버(numWaitingPlaces)를 초기화.
        // vehicleList 의 인스턴스를 생성.
        public DeliveryVehicleManager(int numWaitingPlaces)
        {
            this.numWaitingPlaces = numWaitingPlaces;
            vehicleList = new ArrayList[numWaitingPlaces];

            // vehicleList 배열의 요소마다 ArrayList 인스턴스를 생성.
            for (int i = 0; i < numWaitingPlaces; i++)
            {
                vehicleList[i] = new ArrayList();
            }
        }

        // checkVehicle 메소드
        // vehicleId 를 확인하여 vehicleList 에 존재하는 자동차인지 확인.
        // 있다면, true 를 반환. 없다면, false 를 반환.
        private bool checkVehicle(int vehicleId)
        {
            for (int i = 0; i < numWaitingPlaces; i++)
            {
                foreach (DeliveryVehicle objVehicle in vehicleList[i])
                {
                    if (vehicleId == objVehicle.vehicleId)
                        return true;
                }
            }

            return false;
        }

        // Readyin 메소드
        // vehicleList[i] 에 요소(DeliveryVehicle)을 삽입.
        public void Readyin(int WaitingPlaceId, int vehicleId, string address, int priority)
        {
            int index;
            
            // 존재하는 자동차 번호인지 확인.
            if (checkVehicle(vehicleId))
            {
                Console.WriteLine("이미 존재하는 자동차 번호입니다!");

                return;
            }

            // 우선 순위에 맞게 vehicleList[i] 중간에 삽입.
            foreach (DeliveryVehicle compareVehicle in vehicleList[WaitingPlaceId - 1])
            {
                if (priority < compareVehicle.priority)
                {
                    index = vehicleList[WaitingPlaceId - 1].IndexOf(compareVehicle);
                    vehicleList[WaitingPlaceId - 1].Insert(index, new DeliveryVehicle(vehicleId, address, priority));

                    // 삽입 후, 메소드 종료.
                    return;
                }
            }

            // vehicleList[i] 마지막에 삽입.
            vehicleList[WaitingPlaceId - 1].Add(new DeliveryVehicle(vehicleId, address, priority));
        }

        // Ready 메소드
        // vehicleLIst[i] 중에 가장 값의 개수가 적은 'i' 를 찾는다.
        // Readyin() 메소드를 호출할 때, 'i + 1' 을 인자로 넘긴다.
        public int Ready(int vehicleId, string address, int priority)
        {
            int index = 0, min = vehicleList[0].Count;

            for (int i = 1; i < numWaitingPlaces; i++)
            {
                if (min > vehicleList[i].Count)
                {
                    index = i;
                    min = vehicleList[i].Count;
                }
            }

            Readyin(index + 1, vehicleId, address, priority);

            return index + 1;
        }

        // Status 메소드
        // 현재 상태를 출력.
        public void Status(StreamWriter sw)
        {
            sw.WriteLine("************************* Delivery Vehicle Info *************************");
            sw.WriteLine($"Number of WaitPlaces: {numWaitingPlaces}");
            for (int i = 0; i < numWaitingPlaces; i++)
            {
                sw.WriteLine($"WaitPlace #{i + 1} Number Vehicles: {vehicleList[i].Count}");
                foreach (DeliveryVehicle objVehicle in vehicleList[i])
                {
                    sw.WriteLine($"FNUM: {objVehicle.vehicleId} DEST: {objVehicle.destination} PRIO: {objVehicle.priority}");
                }
                sw.WriteLine("--------------------------------------------------");
            }
            sw.WriteLine("*********************** End Delivery Vehicle Info ***********************");
        }

        // Cancel 메소드
        // vehicleId 가 일치하는 자동차의 index 를 vehicleList 에서 찾고, 이를 이용하여 삭제.
        public bool Cancel(int vehicleId)
        {
            int index;

            for (int i = 0; i < numWaitingPlaces; i++)
            {
                foreach (DeliveryVehicle objVehicle in vehicleList[i])
                {
                    if (vehicleId == objVehicle.vehicleId)
                    {
                        index = vehicleList[i].IndexOf(objVehicle);
                        vehicleList[i].RemoveAt(index);

                        return true;
                    }
                }
            }

            Console.WriteLine("존재하지 않는 자동차 번호입니다!");

            return false;
        }

        // Deliver 메소드
        // 입력 받은 번호의 대기 장소에서 vehicleList[i] 맨 앞에 있는 요소를 제거.
        public int Deliver(int WaitingPlaceId)
        {
            int vehicleId;

            DeliveryVehicle delVehicle;

            if (vehicleList[WaitingPlaceId - 1].Count == 0)
            {
                Console.WriteLine("대기 장소에 자동차가 존재하지 않습니다!");

                return -1;
            }

            delVehicle = vehicleList[WaitingPlaceId - 1][0] as DeliveryVehicle;
            if (delVehicle == null)
                Console.WriteLine("delVehicle, 형변환 실패!");

            vehicleId = delVehicle.vehicleId;

            vehicleList[WaitingPlaceId - 1].RemoveAt(0);

            return vehicleId;
        }

        // Clear 메소드
        // vehicleList[i] 의 요소들을 모두 제거.
        public void Clear(int WaitingPlaceId)
        {
            vehicleList[WaitingPlaceId - 1].Clear();
        }
    }
}
