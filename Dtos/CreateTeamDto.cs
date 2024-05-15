﻿using System.ComponentModel.DataAnnotations;

namespace HockeyLeague.Api.Dtos;

public record class CreateTeamDto
(
    [Required][StringLength(50)] string Name,
    [Required][Range(1, 3)] int Division
);
