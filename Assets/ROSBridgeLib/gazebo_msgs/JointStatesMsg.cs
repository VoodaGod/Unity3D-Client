﻿using System.Collections;
using System.Text;
using SimpleJSON;
using System.Collections.Generic;


namespace ROSBridgeLib
{
    namespace gazebo_msgs
    {
        public class JointStatesMsg : ROSBridgeMsg
        {
            /*private List<string> _name;
            private List<double> _position;
            private List<double> _rate;
            private List<geometry_msgs.Vector3Msg> _axes;
            private List<geometry_msgs.Vector3Msg> _body1Forces;
            private List<geometry_msgs.Vector3Msg> _body2Forces;
            private List<geometry_msgs.Vector3Msg> _body1Torques;
            private List<geometry_msgs.Vector3Msg> _body2Torques;*/

            private string[] _name;
            private double[] _position;
            private double[] _rate;
            private geometry_msgs.Vector3Msg[] _axes;
            private geometry_msgs.Vector3Msg[] _body1Forces;
            private geometry_msgs.Vector3Msg[] _body2Forces;
            private geometry_msgs.Vector3Msg[] _body1Torques;
            private geometry_msgs.Vector3Msg[] _body2Torques;

            public JointStatesMsg(JSONNode msg)
            {
                /*_name = new List<string>(msg["name"].ToList());
                _position = new List<double>(msg["position"].ToList());
                _rate = new List<double>(msg["rate"].ToList());
                _axes = new List<geometry_msgs.Vector3Msg>(msg["axes"].ToList());
                _body1Forces = new List<geometry_msgs.Vector3Msg>(msg["body1Forces"].ToList());
                _body2Forces = new List<geometry_msgs.Vector3Msg>(msg["body2Forces"].ToList());
                _body1Torques = new List<geometry_msgs.Vector3Msg>(msg["body1Torques"].ToList());
                _body2Torques = new List<geometry_msgs.Vector3Msg>(msg["body2Torques"].ToList());*/

                _name = new string[msg["name"].Count];
                for (int i = 0; i < _name.Length; i++)
                {
                    _name[i] = msg["name"][i];
                }

                _position = new double[msg["position"].Count];
                for (int i = 0; i < _position.Length; i++)
                {
                    _position[i] = msg["position"][i].AsFloat;
                }

                _rate = new double[msg["rate"].Count];
                for (int i = 0; i < _rate.Length; i++)
                {
                    _rate[i] = msg["rate"][i].AsFloat;
                }

                _axes = new geometry_msgs.Vector3Msg[msg["axes"].Count];
                for (int i = 0; i < _axes.Length; i++)
                {
                    _axes[i] = new geometry_msgs.Vector3Msg(msg["axes"][i]);
                }

                _body1Forces = new geometry_msgs.Vector3Msg[msg["body_1_forces"].Count];
                for (int i = 0; i < _body1Forces.Length; i++)
                {
                    _body1Forces[i] = new geometry_msgs.Vector3Msg(msg["body_1_forces"][i]);
                }

                _body2Forces = new geometry_msgs.Vector3Msg[msg["body_2_forces"].Count];
                for (int i = 0; i < _body2Forces.Length; i++)
                {
                    _body2Forces[i] = new geometry_msgs.Vector3Msg(msg["body_2_forces"][i]);
                }

                _body1Torques = new geometry_msgs.Vector3Msg[msg["body_1_torques"].Count];
                for (int i = 0; i < _body1Torques.Length; i++)
                {
                    _body1Torques[i] = new geometry_msgs.Vector3Msg(msg["body_1_torques"][i]);
                }

                _body2Torques = new geometry_msgs.Vector3Msg[msg["body_2_torques"].Count];
                for (int i = 0; i < _body2Torques.Length; i++)
                {
                    _body2Torques[i] = new geometry_msgs.Vector3Msg(msg["body_2_torques"][i]);
                }
            }

            public JointStatesMsg(string[] name, double[] position, double[] rate, 
                geometry_msgs.Vector3Msg[] axes, 
                geometry_msgs.Vector3Msg[] body1Forces, 
                geometry_msgs.Vector3Msg[] body2Forces, 
                geometry_msgs.Vector3Msg[] body1Torques, 
                geometry_msgs.Vector3Msg[] body2Torques)
            {
                _name = name;
                _position = position;
                _rate = rate;
                _axes = axes;
                _body1Forces = body1Forces;
                _body2Forces = body2Forces;
                _body1Torques = body1Torques;
                _body2Torques = body2Torques;
            }

            public static string GetMessageType()
            {
                return "gazebo_msgs/JointStates";
            }

            public string[] GetName()
            {
                return _name;
            }

            public override string ToString()
            {

                return "JointStates [name=" + StringArrayToString(_name) + ", " + "position=" + DoubleArrayToString(_position) + ", rate=" + DoubleArrayToString(_rate) +
                    ", axes=" + _axes.ToString() + ", body_1_forces=" + _body1Forces.ToString() + ", body_2_forces=" + _body2Forces.ToString() +
                    ", body_1_torques=" + _body1Torques.ToString() + ", body_2_torques=" + _body2Torques.ToString() + "]";
            }

            public override string ToYAMLString()
            {
                return "{\"name\" : \"" + StringArrayToString(_name) + "\", \"position\" : " + DoubleArrayToString(_position) + ", \"rate\" : " + DoubleArrayToString(_rate) +
                    ", axes=" + Vec3MsgArrayToYAMLString(_axes) + 
                    ", \"body_1_forces\" : " + Vec3MsgArrayToYAMLString(_body1Forces) + ", \"body_2_forces\" : " + Vec3MsgArrayToYAMLString(_body2Forces) + 
                    ", \"body_1_torques\" : " + Vec3MsgArrayToYAMLString(_body1Torques) + ", \"body_2_torques\" : " + Vec3MsgArrayToYAMLString(_body2Torques) + "}"; 
            }

            private string StringArrayToString(string[] array)
            {
                string result = "[" + string.Join(", ", array) + "]";

                return result;
            }

            private string DoubleArrayToString(double[] array)
            {
                string result = "[";
                for (int i = 0; i < array.Length; i++)
                {
                    result += array[i].ToString();
                    if (i < array.Length - 1)
                    {
                        result += ", ";
                    }
                }
                result += "]";

                return result;
            }

            private string Vec3MsgArrayToYAMLString(geometry_msgs.Vector3Msg[] array)
            {
                string result = "[";
                for (int i = 0; i < array.Length; i++)
                {
                    result += array[i].ToYAMLString();
                    if (i < array.Length - 1)
                    {
                        result += ", ";
                    }
                }
                result += "]";

                return result;
            }
        }
    }
}