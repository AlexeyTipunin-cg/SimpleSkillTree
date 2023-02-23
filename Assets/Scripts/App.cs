using Assets.Scripts.Tree;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class App : MonoBehaviour
    {
        List<SkillModel> skills = new List<SkillModel>()
        {
            new SkillModel("База", 0, true),
            new SkillModel("1", 1, false),
            new SkillModel("2", 1, false),
            new SkillModel("3", 1, false),
            new SkillModel("4", 1, false),
            new SkillModel("5", 1, false),
            new SkillModel("6", 1, false),
            new SkillModel("7", 1, false),
            new SkillModel("8", 1, false),
            new SkillModel("9", 1, false),
            new SkillModel("10", 1, false),
        };

        private void Start()
        {

            Dictionary<string, Node<SkillModel>> skillModels = new Dictionary<string, Node<SkillModel>>();
            foreach (var model in skills)
            {
                skillModels.Add(model.id, new Node<SkillModel>(model));
            }

            List<Edge<Node<SkillModel>>> edges = new List<Edge<Node<SkillModel>>>();
            edges.Add(new Edge<Node<SkillModel>>(skillModels["База"], skillModels["1"]));
            edges.Add(new Edge<Node<SkillModel>>(skillModels["База"], skillModels["2"]));
            edges.Add(new Edge<Node<SkillModel>>(skillModels["База"], skillModels["4"]));
            edges.Add(new Edge<Node<SkillModel>>(skillModels["База"], skillModels["8"]));
            edges.Add(new Edge<Node<SkillModel>>(skillModels["База"], skillModels["9"]));
            edges.Add(new Edge<Node<SkillModel>>(skillModels["4"], skillModels["5"]));
            edges.Add(new Edge<Node<SkillModel>>(skillModels["4"], skillModels["6"]));
            edges.Add(new Edge<Node<SkillModel>>(skillModels["5"], skillModels["7"]));
            edges.Add(new Edge<Node<SkillModel>>(skillModels["6"], skillModels["7"]));
            edges.Add(new Edge<Node<SkillModel>>(skillModels["2"], skillModels["3"]));
            edges.Add(new Edge<Node<SkillModel>>(skillModels["8"], skillModels["10"]));
            edges.Add(new Edge<Node<SkillModel>>(skillModels["9"], skillModels["10"]));
        }
    }
}