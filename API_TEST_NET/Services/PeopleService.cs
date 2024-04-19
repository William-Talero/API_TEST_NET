using API_TEST_NET.Controllers;

namespace API_TEST_NET.Services
{
    public class PeopleService: IPeopleService
    {
        public bool Validate(People people)
        {
            if(String.IsNullOrEmpty(people.Name))
            {
                return false;
            }

            return true;
        }
    }
}
