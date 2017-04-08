﻿using System.Collections.Generic;
using PrtgAPI.Request;

namespace PrtgAPI.Parameters
{
    /// <summary>
    /// Represents parameters used to construct a <see cref="PrtgUrl"/>.
    /// </summary>
    public class Parameters
    {
        private readonly Dictionary<Parameter, object> parameters = new Dictionary<Parameter, object>();

        /// <summary>
        /// Retrieve the underlying dictionary of parameters.
        /// </summary>
        /// <returns></returns>
        public Dictionary<Parameter, object> GetParameters()
        {
            return parameters;
        }

        /// <summary>
        /// Add or update a <see cref="Parameter"/> for use in a <see cref="PrtgUrl"/>.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public object this[Parameter parameter]
        {
            get
            {
                return parameters.ContainsKey(parameter) ? parameters[parameter] : null;
            }
            set
            {
                if (parameters.ContainsKey(parameter))
                {
                    parameters[parameter] = value;
                }
                else
                {
                    //we can only have one authentication type
                    if (parameter == Parameter.PassHash && parameters.ContainsKey(Parameter.Password))
                    {
                        parameters.Remove(Parameter.Password);
                    }
                    else if (parameter == Parameter.Password && parameters.ContainsKey(Parameter.PassHash))
                    {
                        parameters.Remove(Parameter.PassHash);
                    }

                    parameters.Add(parameter, value);
                }
            }
        }
    }
}
