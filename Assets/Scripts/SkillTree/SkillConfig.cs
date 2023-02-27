using Assets.Scripts.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SkillTree
{
    public class SkillConfig
    {
        private List<SkillModel> _skills = new List<SkillModel>()
        {
            new SkillModel("База", new Resource{type = ResourceTypes.SkillPoints, value = 0}, true, false, new List<string>{"1", "4", "2", "8", "9"}),
            new SkillModel("1", new Resource{type = ResourceTypes.SkillPoints, value = 1}, false, true,new List<string>{"База" }),
            new SkillModel("2", new Resource{type = ResourceTypes.SkillPoints, value = 1}, false, true, new List<string>{ "База", "3"}),
            new SkillModel("3", new Resource{type = ResourceTypes.SkillPoints, value = 1}, false, true, new List<string>{ "2"}),
            new SkillModel("4", new Resource{type = ResourceTypes.SkillPoints, value = 1}, false, true, new List<string>{ "База", "5", "6" }),
            new SkillModel("5", new Resource{type = ResourceTypes.SkillPoints, value = 1}, false, true, new List<string>{ "4", "7" }),
            new SkillModel("6", new Resource{type = ResourceTypes.SkillPoints, value = 1}, false, true, new List<string>{"4", "7" }),
            new SkillModel("7", new Resource{type = ResourceTypes.SkillPoints, value = 1}, false, true, new List<string>{"5", "6" }),
            new SkillModel("8", new Resource{type = ResourceTypes.SkillPoints, value = 1}, false, true, new List<string>{ "База", "10" }),
            new SkillModel("9", new Resource{type = ResourceTypes.SkillPoints, value = 1}, false, true, new List<string>{ "База", "10" }),
            new SkillModel("10", new Resource{type = ResourceTypes.SkillPoints, value = 1}, false, true, new List<string>{"8", "9" }),
        };

        private Dictionary<string, int> _skillToIcon = new Dictionary<string, int>
        {
            {"База", 0 },
            {"1", 1},
            {"2", 2},
            {"3", 3},
            {"4", 4},
            {"5", 5},
            {"6", 6},
            {"7", 7},
            {"8", 8},
            {"9", 9 },
            {"10", 10 },
        };

        public List<SkillModel> skills => _skills;
        public Dictionary<string, int> skillToIcon => _skillToIcon;
    }
}
