
using System;
namespace ToDoCalendar.Models
{
    public class Entry : BaseModel
    {
        string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value != null)
                {
                    _title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        string _content;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                if (value != null)
                {
                    _content = value;
                    RaisePropertyChanged("Content");
                }
            }
        }

        DateTime _createDate;
        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                if (value != null)
                {
                    _createDate = value;
                    RaisePropertyChanged("CreateDateString");
                }
            }
        }
        public string CreateDateString
        {
            get
            {
                return _createDate.ToShortDateString();
            }
        }


        DateTime _lastEditDate;
        public DateTime LastEditDate
        {
            get
            {
                return _lastEditDate;
            }
            set
            {
                if (value != null)
                {
                    _lastEditDate = value;
                    RaisePropertyChanged("LastEditDateString");
                }
            }
        }

        public string LastEditDateString
        {
            get
            {
                return _lastEditDate.ToShortDateString();
            }
        }
    }
}
