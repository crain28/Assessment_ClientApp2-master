namespace Assessment_ClientApp2
{
    /// <summary>
    /// monster entity class
    /// </summary>
    public class Monster
    {
        public enum EmotionalState
        {
            none,
            happy,
            sad,
            angry,
            bored
        }

        public enum TribeName
        {
            tabo,
            dewa,
            caltar,
            silva, 
            capar
        }


        #region FIELDS

        //--TODO Add Field/Propertys: TRIBE[string]
        //--Done

        private string _name;
        private int _age;
        private EmotionalState _attitude;
        private TribeName _tribe;
        private bool _active;

        #endregion

        #region PROPERTIES

        
        // --TODO Add fields/propertys: Tribe[enum], Actice[bool]
        // --Done
       

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public EmotionalState Attitude
        {
            get { return _attitude; }
            set { _attitude = value; }
        }

        public TribeName Tribe
        {
            get { return _tribe; }
            set { _tribe = value; }
        }
       
        public bool Active 
        {
            get { return _active; }
            set { _active = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Monster()
        {

        }

        public Monster(string name, int age, EmotionalState attitude, TribeName tribe, bool active)
        {
            _name = name;
            _age = age;
            _attitude = attitude;
            _tribe = tribe;
            _active = active;
        }

        #endregion

        #region METHODS

        public string Greeting()
        {
            string greeting;

            switch (_attitude)
            {
                case EmotionalState.happy:
                    greeting = $"Hello, my name is {_name} and I am having a great day!";
                    break;

                case EmotionalState.sad:
                    greeting = $"{_name} is feeling bad.";
                    break;

                case EmotionalState.angry:
                    greeting = $"I'm {_name}, and stay away from me!";
                    break;

                case EmotionalState.bored:
                    greeting = $"I don't know what to do at {_age} years old.";
                    break;

                default:
                    greeting = $"Hello, my name is {_name}.";
                    break;
            }
            return greeting;
        }

        public string MyTribe()
        {
            string mytribe;

            switch (_tribe)
            {
                case TribeName.tabo:
                    mytribe = $"Hello, I am in the {_tribe} Tribe which is known for its tribal rituals";
                    break;
                    
                case TribeName.dewa:
                    mytribe = $"Hello, I am in the {_tribe} Tribe which is known for its voyages to distant lands";
                    break;

                case TribeName.caltar:
                    mytribe = $"Hello, I am in the {_tribe} Tribe which is known for its Hunting parties";
                    break;

                case TribeName.silva:
                    mytribe = $"Hello, I am in the {_tribe} Tribe which is known for its weapon making talents";
                    break;
                    
                default:
                    mytribe = $"Hello, My name is {_name}.";
                    break;                                     
            }
                return mytribe;
        }


      
        #endregion
    }
}
