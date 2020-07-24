/*
 * File: Time.cs
 * File Created: Friday, 24th July 2020 7:33:07 pm
 * ––––––––––––––––––––––––
 * Author: Jesus Fermin, 'Pokoi', Villar  (hello@pokoidev.com)
 * ––––––––––––––––––––––––
 * MIT License
 * 
 * Copyright (c) 2020 Pokoidev
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of
 * this software and associated documentation files (the "Software"), to deal in
 * the Software without restriction, including without limitation the rights to
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
 * of the Software, and to permit persons to whom the Software is furnished to do
 * so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System.Collections.Generic;
using System;
using UnityEngine;

namespace Garden
{
    [Serializable]
    public class Time : System
    {
        Dictionary<string, ClockComponent> components;
        
        [SerializeField]  float dayInSeconds;

        public Time()
        {
            components = new Dictionary<string, ClockComponent>();
        }

        /// <summary>
        /// Adds a component to the system
        /// </summary>
        /// <param name="name"> The name of the component </param>
        /// <param name="clock"> The component to add </param>
        public void AddComponent(string name, ClockComponent clock) => components.Add(name, clock);

        /// <summary>
        /// Removes a component 
        /// </summary>
        /// <param name="name"></param>
        public void RemoveComponent(string name) => components.Remove(name);

        /// <summary>
        /// Updates the system
        /// </summary>
        /// <param name="delta"></param>
        public override void Update(float delta)
        {
            foreach (KeyValuePair<string, ClockComponent> component in components)
            {
                component.Value.Execute(delta * dayInSeconds);
            }
        }

        /// <summary>
        /// Get a component by his name
        /// </summary>
        /// <param name="name"> The name of the component </param>
        /// <returns></returns>
        public ClockComponent GetComponent(string name) => components[name];

        public override void Init()
        {
            
        }
    }

}

