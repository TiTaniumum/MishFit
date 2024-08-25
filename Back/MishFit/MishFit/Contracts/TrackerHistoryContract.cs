using MishFit.Entities;
using MishFit.Enums;

namespace MishFit.Contracts;

public record TrackerHistoryContract(
    TrackerType TrackerType,
    DateTime DateFrom,
    DateTime DateTo
    );