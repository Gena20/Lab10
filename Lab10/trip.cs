namespace Lab10
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class trip
    {
        public int id { get; set; }

        public int car_id { get; set; }

        public int object_form_id { get; set; }

        public int object_to_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_from { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_to { get; set; }

        public TimeSpan? time { get; set; }

        public virtual car car { get; set; }

        public virtual _object _object { get; set; }

        public virtual _object object1 { get; set; }
    }
}
