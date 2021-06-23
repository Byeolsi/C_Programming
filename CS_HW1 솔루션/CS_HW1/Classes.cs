using System;

namespace CS_HW1
{
    /* 컴퓨터 */

    // Computer 클래스 (부모 클래스)
    class Computer
    {
        // ComType - 0 : Netbook / 1 : Notebook / 2 : Desktop
        public byte ComType { get; init; }
        public uint ComId { get; init; }
        public uint RentUserId { get; set; }
        public uint DR { get; set; }
        public uint DL { get; set; }
        public uint DU { get; set; }
        public bool Avail { get; set; } = true;

        /* 생성자 */
        public Computer(byte type, uint Id)
        {
            this.ComId = Id;
            this.ComType = type;
        }
    }

    // Netbook 클래스 (자식 클래스)
    class Netbook : Computer
    {
        public uint NetId { get; init; }

        /* 생성자 */
        public Netbook(byte type, uint Id, uint netId) : base(type, Id)
        {
            this.NetId = netId;
        }
    }

    // Notebook 클래스 (자식 클래스)
    class Notebook : Computer
    {
        public uint NoteId { get; init; }

        /* 생성자 */
        public Notebook(byte type, uint Id, uint noteId) : base(type, Id)
        {
            this.NoteId = noteId;
        }
    }

    // Desktop 클래스 (자식 클래스)
    class Desktop : Computer
    {
        public uint DeskId { get; init; }

        /* 생성자 */
        public Desktop(byte type, uint Id, uint deskId) : base(type, Id)
        {
            this.DeskId = deskId;
        }
    }

    /* 유저 */

    // User 클래스 (부모 클래스)
    class User
    {
        // UserType - 0 : Workers / 1 : Students / 2 : Gamers
        public byte UserType { get; init; }
        public uint UserId { get; init; }
        public string UserName { get; init; }
        public uint RentedCom { get; set; }
        public bool Rent { get; set; } = false;

        /* 생성자 */
        public User(byte type, uint Id, string name)
        {
            this.UserType = type;
            this.UserId = Id;
            this.UserName = name;
        }
    }

    // Workers 클래스 (자식 클래스)
    class Workers : User
    {
        public uint WorkerId { get; init; }

        /* 생성자 */
        public Workers(byte type, uint Id, uint workerId, string name) : base(type, Id, name)
        {
            this.WorkerId = workerId;
        }
    }

    // Students 클래스 (자식 클래스)
    class Students : User
    {
        public uint StudId { get; init; }

        /* 생성자 */
        public Students(byte type, uint Id, uint studId, string name) : base(type, Id, name)
        {
            this.StudId = studId;
        }
    }

    // Gamers 클래스 (자식 클래스)
    class Gamers : User
    {
        public uint GamerId { get; init; }

        /* 생성자 */
        public Gamers(byte type, uint Id, uint gamerId, string name) : base(type, Id, name)
        {
            this.GamerId = gamerId;
        }
    }
}
