using System;

namespace Common
{
    public interface IMineable
    {
        public float MineableFullAmount { get; set; }
        public float MineableAmount { get; set; }
    }
}