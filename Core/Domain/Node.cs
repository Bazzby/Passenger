using System;
using System.Text.RegularExpressions;

namespace Core.Domain
{
    public class Node
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
        public string Address { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Node()
        {
        }

        protected Node(string address, double longitude, double latitude)
        {
            SetAddress(address);
            SetLongitude(longitude);
            SetLatitude(latitude);
        }

        public void SetAddress(string address)
        {
            if (!NameRegex.IsMatch(address))
            {
                throw new Exception("Address is invalid.");
            }
            if (Address == address)
            {
                return;
            }

            Address = address;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetLongitude(double longitude)
        {
            if (longitude < -180 || longitude > 180)
            {
                throw new Exception("Longitude must be a number between -180 and 180.");
            }
            if (Longitude == longitude)
            {
                return;
            }

            Longitude = longitude;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetLatitude(double latitude)
        {
            if (latitude < -90 || latitude > 90)
            {
                throw new Exception("Latitude must be a number between -90 and 90.");
            }
            if (Latitude == latitude)
            {
                return;
            }

            Latitude = latitude;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Node Create(string address, double longitude, double latitude)
            => new Node(address, longitude, latitude);
    }
}
