using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace syStudy.Models
{
    public class Board
    {
        /// <summary>
        /// 게시물 번호
        /// </summary>
        [Key] 
        public int BoardNo { get; set; }

        /// <summary>
        /// 게시물 제목
        /// </summary>
        [Required]
        public string BoardTile { get; set; }

        /// <summary>
        /// 게시물 내용
        /// </summary>
        [Required]
        public string BoardContents { get; set; }

        /// <summary>
        /// 작성자 번호
        /// </summary>
        [Required]
        public int UserNo { get; set; }

        [ForeignKey("UserNo")]
        public virtual User User { get; set; }
    }
}
