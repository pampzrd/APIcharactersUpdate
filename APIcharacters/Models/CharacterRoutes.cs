using APIcharacters.Data;
using Microsoft.EntityFrameworkCore;

namespace APIcharacters.Models;

public static class CharacterRoutes
{
    public static void CharactersRoutes(this WebApplication app)
    {
        var routesCharacters = app.MapGroup("characters");
        routesCharacters.MapGet("", async (AppDbContext context, CancellationToken ct) =>
        {
            var characters = await context
                .Characters
                .Where(character => character.Active)
                .Select(character => new CharacterDTO(character.Name, character.Birthplace, character.Preferences,
                    character.Age, character.Goals, character.Fears))
                .ToListAsync(ct);
            return characters;

        });

        routesCharacters.MapPost("", async (AddCharacter request,AppDbContext context,CancellationToken ct) =>
        {
            var exists = await context.Characters
                .AnyAsync(character => character.Name == request.name, ct);
            if (exists)
                return Results.Conflict("Já existe esse personagem!");
            var newCharacter = new Character(request.name,request.birthplace,request.preferences,request.age,request.goals,request.fears);
            await context.Characters.AddAsync(newCharacter, ct);
            await context.SaveChangesAsync(ct);
            var retornoCharacter = new CharacterDTO(newCharacter.Name,newCharacter.Birthplace,newCharacter.Preferences,newCharacter.Age,newCharacter.Goals,newCharacter.Fears);
            return Results.Ok(retornoCharacter);

        });

        routesCharacters.MapPut("{name}", async (string name,UpdateCharacter request, AppDbContext context, CancellationToken ct) =>
        {
            var characters = await context.Characters
                .SingleOrDefaultAsync(character => character.Name == name, ct);
            if (characters == null)
                return Results.NotFound();

            characters.UpdateDescription(request.name,request.birthplace,request.preferences,request.age,request.goals,request.fears);
            await context.SaveChangesAsync(ct);
            return Results.Ok(new CharacterDTO(characters.Name, characters.Birthplace, characters.Preferences,
                characters.Age, characters.Goals, characters.Fears));
   
        });

        routesCharacters.MapDelete("{name}", async (string name,AppDbContext context,CancellationToken ct) =>
        {
            var characters = await context.Characters.SingleOrDefaultAsync(character => character.Name == name, ct);
            if(characters==null)
                return Results.NotFound();
            characters.Deactivate();
            await context.SaveChangesAsync(ct);
            return Results.Ok();
        });

    }
}