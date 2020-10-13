using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature.Actions;
using ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableFeature;

namespace ThePeriodicTableOfElementsGame.GamePlay.ElementsSpeedMatchGameFeature
{
	public class ElementsSpeedMatchGameState
	{
		public readonly IEnumerable<ElementState> ElementStates;
		public readonly ReadOnlyDictionary<int, object> ElementTimings;
		public readonly byte? HighlightedAtomicNumber;

		public ElementsSpeedMatchGameState(
			IEnumerable<ElementState> elementStates,
			ReadOnlyDictionary<int, object> elementTimings,
			byte? highlightedAtomicNumber)
		{
			ElementStates = elementStates;
			ElementTimings = elementTimings;
			HighlightedAtomicNumber = highlightedAtomicNumber;
		}

		public ElementsSpeedMatchGameState With(
			PropertyUpdate<IEnumerable<ElementState>> elementStates = null,
			PropertyUpdate<ReadOnlyDictionary<int, object>> elementTimings = null,
			PropertyUpdate<byte?> highlightedAtomicNumber = null)
			=>
				new ElementsSpeedMatchGameState(
					elementStates: elementStates.GetUpdatedValue(ElementStates),
					elementTimings: elementTimings.GetUpdatedValue(ElementTimings),
					highlightedAtomicNumber: highlightedAtomicNumber.GetUpdatedValue(HighlightedAtomicNumber));
	}

	public static class ElementsSpeedMatchGameStateExtensions
	{
		public static readonly ElementsSpeedMatchGameState DefaultState =
			new ElementsSpeedMatchGameState(
				highlightedAtomicNumber: PropertyUpdate<byte?>.Default,
				elementStates: Enumerable.Range(1, 118)
					.Select(x => new ElementState(
						atomicNumber: (byte)x,
						front: new CardState(),
						back: new CardState(),
						concealed: false))
					.ToArray(),
				elementTimings: new ReadOnlyDictionary<int, object>(
					new Dictionary<int, object>
					{
						[009_367] = new HighlightElementAction(051), // Sb
						[009_843] = new HighlightElementAction(033), // As
						[010_350] = new HighlightElementAction(013), // Al
						[010_813] = new HighlightElementAction(034), // Se
						[011_345] = new HighlightElementAction(001), // H
						[011_886] = new HighlightElementAction(008), // O
						[012_326] = new HighlightElementAction(007), // N
						[012_816] = new HighlightElementAction(075), // Re
						[013_347] = new HighlightElementAction(028), // Ni
						[013_894] = new HighlightElementAction(060), // Nd
						[014_428] = new HighlightElementAction(093), // Np
						[014_920] = new HighlightElementAction(032), // Ge 
						[015_420] = new HighlightElementAction(026), // Fe
						[015_972] = new HighlightElementAction(095), // Am
						[016_510] = new HighlightElementAction(044), // Ru
						[017_050] = new HighlightElementAction(092), // U
						[017_547] = new HighlightElementAction(063), // Eu
						[018_075] = new HighlightElementAction(040), // Zr
						[018_599] = new HighlightElementAction(071), // Lu
						[019_137] = new HighlightElementAction(023), // V
						[019_633] = new HighlightElementAction(057), // La
						[020_180] = new HighlightElementAction(076), // Os
						[020_696] = new HighlightElementAction(085), // At
						[021_232] = new HighlightElementAction(088), // Ra
						[021_750] = new HighlightElementAction(079), // Au
						[022_278] = new HighlightElementAction(091), // Pa
						[022_800] = new HighlightElementAction(049), // In
						[023_284] = new HighlightElementAction(031), // Ga
						[024_829] = new HighlightElementAction(053), // I
						[025_408] = new HighlightElementAction(090), // Th
						[025_979] = new HighlightElementAction(069), // Tm
						[026_563] = new HighlightElementAction(081), // Tl
						[029_213] = new HighlightElementAction(039), // Y
						[029_670] = new HighlightElementAction(070), // Yb
						[030_235] = new HighlightElementAction(089), // Ac
						[030_771] = new HighlightElementAction(037), // Rb
						[031_278] = new HighlightElementAction(005), // B
						[031_802] = new HighlightElementAction(064), // Gd
						[032_337] = new HighlightElementAction(041), // Nb
						[032_796] = new HighlightElementAction(077), // Ir
						[033_370] = new HighlightElementAction(038), // Sr
						[033_838] = new HighlightElementAction(014), // Si
						[034_394] = new HighlightElementAction(047), // Ag
						[034_991] = new HighlightElementAction(062), // Sm
						[035_503] = new HighlightElementAction(083), // Bi
						[035_823] = new HighlightElementAction(035), // Br
						[036_129] = new HighlightElementAction(003), // Li
						[036_591] = new HighlightElementAction(004), // Be
						[037_127] = new HighlightElementAction(056), // Ba
						//[005_000] = new HighlightElementAction(067), // Ho
						//[005_000] = new HighlightElementAction(002), // He
						//[005_000] = new HighlightElementAction(072), // Hf
						//[005_000] = new HighlightElementAction(068), // Er
						//[005_000] = new HighlightElementAction(015), // P
						//[005_000] = new HighlightElementAction(087), // Fr
						//[005_000] = new HighlightElementAction(009), // F
						//[005_000] = new HighlightElementAction(065), // Tb
						//[005_000] = new HighlightElementAction(025), // Mn
						//[005_000] = new HighlightElementAction(080), // Hg
						//[005_000] = new HighlightElementAction(042), // Mo
						//[005_000] = new HighlightElementAction(012), // Mg
						//[005_000] = new HighlightElementAction(066), // Dy
						//[005_000] = new HighlightElementAction(021), // Sc
						//[005_000] = new HighlightElementAction(058), // Ce
						//[005_000] = new HighlightElementAction(055), // Cs
						//[005_000] = new HighlightElementAction(082), // Pb
						//[005_000] = new HighlightElementAction(059), // Pr
						//[005_000] = new HighlightElementAction(078), // Pt
						//[005_000] = new HighlightElementAction(094), // Pu
						//[005_000] = new HighlightElementAction(046), // Pd
						//[005_000] = new HighlightElementAction(061), // Pm
						//[005_000] = new HighlightElementAction(019), // K
						//[005_000] = new HighlightElementAction(084), // Po
						//[005_000] = new HighlightElementAction(073), // Ta
						//[005_000] = new HighlightElementAction(043), // Tc
						//[005_000] = new HighlightElementAction(022), // Ti
						//[005_000] = new HighlightElementAction(052), // Te
						//[005_000] = new HighlightElementAction(048), // Cd
						//[005_000] = new HighlightElementAction(020), // Ca
						//[005_000] = new HighlightElementAction(024), // Cr
						//[005_000] = new HighlightElementAction(096), // Cm
						//[005_000] = new HighlightElementAction(016), // S
						//[005_000] = new HighlightElementAction(098), // Cf
						//[005_000] = new HighlightElementAction(100), // Fm
						//[005_000] = new HighlightElementAction(097), // Bk
						//[005_000] = new HighlightElementAction(101), // Md
						//[005_000] = new HighlightElementAction(099), // Es
						//[005_000] = new HighlightElementAction(102), // No
						//[005_000] = new HighlightElementAction(018), // Ar
						//[005_000] = new HighlightElementAction(036), // Kr
						//[005_000] = new HighlightElementAction(010), // Ne
						//[005_000] = new HighlightElementAction(086), // Rn
						//[005_000] = new HighlightElementAction(054), // Xe
						//[005_000] = new HighlightElementAction(030), // Zn
						//[005_000] = new HighlightElementAction(045), // Rh
						//[005_000] = new HighlightElementAction(017), // Cl
						//[005_000] = new HighlightElementAction(006), // C
						//[005_000] = new HighlightElementAction(027), // Co
						//[005_000] = new HighlightElementAction(029), // Cu
						//[005_000] = new HighlightElementAction(074), // W
						//[005_000] = new HighlightElementAction(050), // Sn
						//[005_000] = new HighlightElementAction(011), // Na
					})
			);
	}
}
