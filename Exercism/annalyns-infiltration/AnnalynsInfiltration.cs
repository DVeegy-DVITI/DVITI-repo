using System;
using System.Linq;

static class QuestLogic
{
    public static bool CanFastAttack(bool knightIsAwake)
    {
        /* [Define] Declare and Initialise variables */
        // (Define-sub) Output Variables
        bool output = default;
        // (Define-sub) Process Variables
        // (Define-sub) Process Logic
        Func<bool, bool> canFastAttack = (knightIsAwake) =>
        {
            return (!knightIsAwake);
        };

        /* [Process] Perform logic on defined variables */
        output = canFastAttack(knightIsAwake);

        /* [Conclude] Perform the method intent (output data) */
        return output;
    }

    public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake)
    {
        /* [Define] Declare and Initialise variables */
        // (Define-sub) Output Variables
        bool output = default;
        // (Define-sub) Process Variables
        (bool KnightIsAwake, bool ArcherIsAwake, bool PrisonerIsAwake) kidnapperCampData = (KnightIsAwake: knightIsAwake, ArcherIsAwake: archerIsAwake, PrisonerIsAwake: prisonerIsAwake);
        // (Define-sub) Process Logic
        Func<(bool, bool, bool), bool> canSpy = ((bool KnightIsAwake, bool ArcherIsAwake, bool PrisonerIsAwake) kidnapperCampData) =>
        {
            bool[] arrPeopleEligibleForSpying = { kidnapperCampData.KnightIsAwake, kidnapperCampData.ArcherIsAwake, kidnapperCampData.PrisonerIsAwake };
            return (arrPeopleEligibleForSpying.Any(person => person)) ? true : false;
        };

        /* [Process] Perform logic on defined variables */
        output = canSpy(kidnapperCampData);

        /* [Conclude] Perform the method intent (output data) */
        return output;
    }

    public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake)
    {
        /* [Define] Declare and Initialise variables */
        // (Define-sub) Output Variables
        bool output = default;
        // (Define-sub) Process Variables
        (bool ArcherIsAwake, bool PrisonerIsAwake) kidnapperCampData = (ArcherIsAwake: archerIsAwake, PrisonerIsAwake: prisonerIsAwake);
        // (Define-sub) Process Logic
        Func<(bool, bool), bool> canSpy = ((bool ArcherIsAwake, bool PrisonerIsAwake) kidnapperCampData) =>
        {
            return (!kidnapperCampData.ArcherIsAwake && kidnapperCampData.PrisonerIsAwake);
        };

        /* [Process] Perform logic on defined variables */
        output = canSpy(kidnapperCampData);

        /* [Conclude] Perform the method intent (output data) */
        return output;
    }

    public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake, bool petDogIsPresent)
    {
        /* [Define] Declare and Initialise variables */
        // (Define-sub) Output Variables
        bool output = default;
        // (Define-sub) Process Variables
        (bool KnightIsAwake, bool ArcherIsAwake, bool PrisonerIsAwake, bool PetDogIsPresent) kidnapperCampData = (KnightIsAwake: knightIsAwake, ArcherIsAwake: archerIsAwake, PrisonerIsAwake: prisonerIsAwake, PetDogIsPresent: petDogIsPresent);
        // (Define-sub) Process Logic
        Func<(bool, bool, bool, bool), bool> canFreeWithDog = ((bool KnightIsAwake, bool ArcherIsAwake, bool PrisonerIsAwake, bool PetDogIsPresent) kidnapperCampData) =>
        {
            return (!kidnapperCampData.ArcherIsAwake);
        };
        Func<(bool, bool, bool, bool), bool> canFreeWithoutDog = ((bool KnightIsAwake, bool ArcherIsAwake, bool PrisonerIsAwake, bool PetDogIsPresent) kidnapperCampData) =>
        {
            return (!kidnapperCampData.KnightIsAwake && !kidnapperCampData.ArcherIsAwake && kidnapperCampData.PrisonerIsAwake);
        };
        Func<(bool, bool, bool, bool), bool> canFreePrisoner = ((bool KnightIsAwake, bool ArcherIsAwake, bool PrisonerIsAwake, bool PetDogIsPresent) kidnapperCampData) =>
        {
            return (kidnapperCampData.PetDogIsPresent) ? canFreeWithDog(kidnapperCampData) : canFreeWithoutDog(kidnapperCampData);
        };

        /* [Process] Perform logic on defined variables */
        output = canFreePrisoner(kidnapperCampData);

        /* [Conclude] Perform the method intent (output data) */
        return output;
    }
}

class Template
{
    public int TemplateMethod(int amountOfLayersInLasagna)
    {
        /* [Define] Declare and Initialise variables */
        // (Define-sub) Output Variables
        int output = default;
        // (Define-sub) Process Variables
        const int preparationTimeInMinutesPerLayer = 2;
        (int AmountOfLayersInLasagna, int PreparationTimeInMinutesPerLayer) lasagnaCookingData = (AmountOfLayersInLasagna: amountOfLayersInLasagna, PreparationTimeInMinutesPerLayer: preparationTimeInMinutesPerLayer);
        // (Define-sub) Process actions
        Func<(int, int), int> actionCalculatePreparationTimeInMinutesBasedOnLayers = ((int AmountOfLayersInLasagna, int PreparationTimeInMinutesPerLayer) lasagnaCookingData) =>
        {
            return (lasagnaCookingData.AmountOfLayersInLasagna * lasagnaCookingData.PreparationTimeInMinutesPerLayer);
        };

        /* [Process] Perform logic on defined variables */
        output = actionCalculatePreparationTimeInMinutesBasedOnLayers(lasagnaCookingData);

        /* [Conclude] Perform the method intent (output data) */
        return output;
    }
}
