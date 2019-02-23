using System;
using System.Collections.Generic;
using System.Text;

namespace AskGoo2.ApplicationCore.Entities.QuestionAggregate
{
    public class Question : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
