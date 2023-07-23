﻿using Entities.Concerts;
using Entities.Tickets;

namespace Entities.Reservation;

public class Reservation : BaseEntity
{
    public string Title { get; set; }
    public int PhoneNumber { get; set; }
    public int Password { get; set; }
    public List<Ticket>Tickets { get; set; }
    public List<Concert> Concerts { get; set; }
}