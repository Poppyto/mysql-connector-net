// Copyright � 2014 Oracle and/or its affiliates. All rights reserved.
//
// MySQL Connector/NET is licensed under the terms of the GPLv2
// <http://www.gnu.org/licenses/old-licenses/gpl-2.0.html>, like most 
// MySQL Connectors. There are special exceptions to the terms and 
// conditions of the GPLv2 as it is applied to this software, see the 
// FLOSS License Exception
// <http://www.mysql.com/about/legal/licensing/foss-exception.html>.
//
// This program is free software; you can redistribute it and/or modify 
// it under the terms of the GNU General Public License as published 
// by the Free Software Foundation; version 2 of the License.
//
// This program is distributed in the hope that it will be useful, but 
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
// or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License 
// for more details.
//
// You should have received a copy of the GNU General Public License along 
// with this program; if not, write to the Free Software Foundation, Inc., 
// 51 Franklin St, Fifth Floor, Boston, MA 02110-1301  USA

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#if EF6
using System.Data.Entity.Spatial;
#endif

namespace MySql.Data.Entity.CodeFirst.Tests
{
#if EF6
    [Table("sakila.store")]
#else
    [Table("store")]
#endif
    public partial class store
    {
        public store()
        {
            customers = new HashSet<customer>();
            inventories = new HashSet<inventory>();
            staffs = new HashSet<staff>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte store_id { get; set; }

        public byte manager_staff_id { get; set; }

        [Column(TypeName = "usmallint")]
        public int address_id { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime last_update { get; set; }

        public virtual address address { get; set; }

        public virtual ICollection<customer> customers { get; set; }

        public virtual ICollection<inventory> inventories { get; set; }

        public virtual ICollection<staff> staffs { get; set; }

        public virtual staff staff { get; set; }
    }
}
