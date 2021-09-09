using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPractice
{
    public class Vertex
    {
        public char Label;
        public bool visited;
        public Vertex(char lab)
        {
            this.Label = lab;
            visited = false;
        }
    }
}
