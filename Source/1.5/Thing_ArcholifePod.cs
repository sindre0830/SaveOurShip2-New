﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RimWorld
{
	class Thing_ArcholifePod : ThingWithComps
	{
		public override IEnumerable<FloatMenuOption> GetFloatMenuOptions(Pawn selPawn)
		{
			List<FloatMenuOption> options = new List<FloatMenuOption>();
			options.AddRange(base.GetFloatMenuOptions(selPawn));
			options.Add(new FloatMenuOption(TranslatorFormattedStringExtensions.Translate("CraftArchocat"), delegate { GeneratePawn("Archocat"); }));
			options.Add(new FloatMenuOption(TranslatorFormattedStringExtensions.Translate("CraftArchomutt"), delegate { GeneratePawn("Archomutt"); }));
			options.Add(new FloatMenuOption(TranslatorFormattedStringExtensions.Translate("CraftArchostrich"), delegate { GeneratePawn("Archostrich"); }));
			options.Add(new FloatMenuOption(TranslatorFormattedStringExtensions.Translate("CraftArchoffalo"), delegate { GeneratePawn("Archoffalo"); }));
			options.Add(new FloatMenuOption(TranslatorFormattedStringExtensions.Translate("CraftArchospider"), delegate { GeneratePawn("Archospider"); }));
			options.Add(new FloatMenuOption(TranslatorFormattedStringExtensions.Translate("CraftArcholope"), delegate { GeneratePawn("Archolope"); }));
			options.Add(new FloatMenuOption(TranslatorFormattedStringExtensions.Translate("CraftArchotortoise"), delegate { GeneratePawn("Archotortoise"); }));
			options.Add(new FloatMenuOption(TranslatorFormattedStringExtensions.Translate("CraftArchopanda"), delegate {GeneratePawn("Archopanda"); }));
			options.Add(new FloatMenuOption(TranslatorFormattedStringExtensions.Translate("CraftArchojerboa"), delegate { GeneratePawn("Archojerboa"); }));
			if(stackCount>=10)
				options.Add(new FloatMenuOption(TranslatorFormattedStringExtensions.Translate("CraftArchothrumbo"), delegate { GeneratePawn("Archothrumbo", 10); }));
			return options;
		}

		void GeneratePawn(string PawnKind, int numPods=1)
		{
			Pawn pawn = PawnGenerator.GeneratePawn(PawnKindDef.Named(PawnKind), Faction.OfPlayer);
			pawn.ageTracker.AgeBiologicalTicks = 0;
			pawn.ageTracker.AgeChronologicalTicks = 0;
			pawn.Position = this.Position;
			List<Hediff> diffs = new List<Hediff>();
			foreach(Hediff diff in pawn.health.hediffSet.hediffs)
			{
				diffs.Add(diff);
			}
			foreach(Hediff diff in diffs)
			{
				pawn.health.RemoveHediff(diff);
			}
			pawn.SpawnSetup(this.Map, false);
			FleckMaker.Static(this.Position, this.Map, FleckDefOf.Smoke);
			this.SplitOff(numPods).Destroy();
		}
	}
}
