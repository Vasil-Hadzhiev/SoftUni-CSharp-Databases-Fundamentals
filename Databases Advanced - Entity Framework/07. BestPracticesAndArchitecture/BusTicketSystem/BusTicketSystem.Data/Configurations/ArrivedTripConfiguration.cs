﻿namespace BusTicketSystem.Data.Configurations
{
    using BusTicketSystem.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ArrivedTripConfiguration : IEntityTypeConfiguration<ArrivedTrip>
    {
        public void Configure(EntityTypeBuilder<ArrivedTrip> builder)
        {
            builder
                .HasOne(at => at.OriginBusStation)
                .WithMany(bs => bs.ArrivedOriginTrips)
                .HasForeignKey(at => at.OriginBusStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(at => at.DestinationBusStation)
                .WithMany(bs => bs.ArrivedDestinationTrips)
                .HasForeignKey(at => at.DestinationBusStationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}