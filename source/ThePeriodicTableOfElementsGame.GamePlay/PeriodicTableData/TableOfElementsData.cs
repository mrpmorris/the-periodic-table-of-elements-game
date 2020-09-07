using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ThePeriodicTableOfElementsGame.GamePlay.PeriodicTableData
{
	public static class TableOfElementsData
	{
		public static ReadOnlyDictionary<int, ElementData> ElementByNumber { get; } = CreateElements();

		private static ReadOnlyDictionary<int, ElementData> CreateElements()
		{
			var dict = new Dictionary<int, ElementData>
			{
				[001] = new ElementData(001, "H", "Hydrogen", 1, 1, ElementGroup.Nonmetal),
				[002] = new ElementData(002, "He", "Helium", 18, 1, ElementGroup.NobleGas),

				[003] = new ElementData(003, "Li", "Lithium", 1, 2, ElementGroup.AlkaliMetal),
				[004] = new ElementData(004, "Be", "Berylium", 2, 2, ElementGroup.AlkalineEarthMetal),
				[005] = new ElementData(005, "B", "Boron", 13, 2, ElementGroup.Semimetal),
				[006] = new ElementData(006, "C", "Carbon", 14, 2, ElementGroup.Nonmetal),
				[007] = new ElementData(007, "N", "Nitrogen", 15, 2, ElementGroup.Nonmetal),
				[008] = new ElementData(008, "O", "Oxygen", 16, 2, ElementGroup.Nonmetal),
				[009] = new ElementData(009, "F", "Fluorine", 17, 2, ElementGroup.Halogen),
				[010] = new ElementData(010, "Ne", "Neon", 18, 2, ElementGroup.NobleGas),

				[011] = new ElementData(011, "Na", "Sodium", 1, 3, ElementGroup.AlkaliMetal),
				[012] = new ElementData(012, "Mg", "Magnesium", 2, 3, ElementGroup.AlkalineEarthMetal),
				[013] = new ElementData(013, "Al", "Aluminium", 13, 3, ElementGroup.BasicMetal),
				[014] = new ElementData(014, "Si", "Silicon", 14, 3, ElementGroup.Semimetal),
				[015] = new ElementData(015, "P", "Phosphorous", 15, 3, ElementGroup.Nonmetal),
				[016] = new ElementData(016, "S", "Sulfur", 16, 3, ElementGroup.Nonmetal),
				[017] = new ElementData(017, "Cl", "Chlorine", 17, 3, ElementGroup.Halogen),
				[018] = new ElementData(018, "Ar", "Argon", 18, 3, ElementGroup.NobleGas),

				[019] = new ElementData(019, "K", "Potassium", 1, 4, ElementGroup.AlkaliMetal),
				[020] = new ElementData(020, "Ca", "Calcium", 2, 4, ElementGroup.AlkalineEarthMetal),
				[021] = new ElementData(021, "Sc", "Scandium", 3, 4, ElementGroup.TransitionMetal),
				[022] = new ElementData(022, "Ti", "Titanium", 4, 4, ElementGroup.TransitionMetal),
				[023] = new ElementData(023, "V", "Vanadium", 5, 4, ElementGroup.TransitionMetal),
				[024] = new ElementData(024, "Cr", "Chromium", 6, 4, ElementGroup.TransitionMetal),
				[025] = new ElementData(025, "Mn", "Manganese", 7, 4, ElementGroup.TransitionMetal),
				[026] = new ElementData(026, "Fe", "Iron", 8, 4, ElementGroup.TransitionMetal),
				[027] = new ElementData(027, "Co", "Cobalt", 9, 4, ElementGroup.TransitionMetal),
				[028] = new ElementData(028, "Ni", "Nickel", 10, 4, ElementGroup.TransitionMetal),
				[029] = new ElementData(029, "Cu", "Copper", 11, 4, ElementGroup.TransitionMetal),
				[030] = new ElementData(030, "Zn", "Zinc", 12, 4, ElementGroup.TransitionMetal),
				[031] = new ElementData(031, "Ga", "Gallium", 13, 4, ElementGroup.BasicMetal),
				[032] = new ElementData(032, "Ge", "Germanium", 14, 4, ElementGroup.Semimetal),
				[033] = new ElementData(033, "As", "Arsenic", 15, 4, ElementGroup.Semimetal),
				[034] = new ElementData(034, "Se", "Selenium", 16, 4, ElementGroup.Nonmetal),
				[035] = new ElementData(035, "Br", "Bromine", 17, 4, ElementGroup.Halogen),
				[036] = new ElementData(036, "Kr", "Krypton", 18, 4, ElementGroup.NobleGas),

				[037] = new ElementData(037, "Rb", "Rubidium", 1, 5, ElementGroup.AlkaliMetal),
				[038] = new ElementData(038, "Sr", "Strontium", 2, 5, ElementGroup.AlkalineEarthMetal),
				[039] = new ElementData(039, "Y", "Yttrium", 3, 5, ElementGroup.TransitionMetal),
				[040] = new ElementData(040, "Zr", "Zirconium", 4, 5, ElementGroup.TransitionMetal),
				[041] = new ElementData(041, "Nb", "Niobium", 5, 5, ElementGroup.TransitionMetal),
				[042] = new ElementData(042, "Mo", "Molybdenum", 6, 5, ElementGroup.TransitionMetal),
				[043] = new ElementData(043, "Tc", "Technetium", 7, 5, ElementGroup.TransitionMetal),
				[044] = new ElementData(044, "Ru", "Ruthenium", 8, 5, ElementGroup.TransitionMetal),
				[045] = new ElementData(045, "Rh", "Rhodium", 9, 5, ElementGroup.TransitionMetal),
				[046] = new ElementData(046, "Pd", "Palladium", 10, 5, ElementGroup.TransitionMetal),
				[047] = new ElementData(047, "Ag", "Silver", 11, 5, ElementGroup.TransitionMetal),
				[048] = new ElementData(048, "Cd", "Cadmium", 12, 5, ElementGroup.TransitionMetal),
				[049] = new ElementData(049, "In", "Indium", 13, 5, ElementGroup.BasicMetal),
				[050] = new ElementData(050, "Sn", "Tin", 14, 5, ElementGroup.BasicMetal),
				[051] = new ElementData(051, "Sb", "Antimony", 15, 5, ElementGroup.Semimetal),
				[052] = new ElementData(052, "Te", "Tellurium", 16, 5, ElementGroup.Semimetal),
				[053] = new ElementData(053, "I", "Iondine", 17, 5, ElementGroup.Halogen),
				[054] = new ElementData(054, "Xe", "Xenon", 18, 5, ElementGroup.NobleGas),

				[055] = new ElementData(055, "Cs", "Cesium", 1, 6, ElementGroup.AlkaliMetal),
				[056] = new ElementData(056, "Ba", "Barium", 2, 6, ElementGroup.AlkalineEarthMetal),
				#region Lathanides 57-71
				[057] = new ElementData(057, "La", "Lanthanum", 3, 8, ElementGroup.Lathanide),
				[058] = new ElementData(058, "Ce", "Cerium", 4, 8, ElementGroup.Lathanide),
				[059] = new ElementData(059, "Pr", "Praseodymium", 5, 8, ElementGroup.Lathanide),
				[060] = new ElementData(060, "Nd", "Neodymium", 6, 8, ElementGroup.Lathanide),
				[061] = new ElementData(061, "Pm", "Promethium", 7, 8, ElementGroup.Lathanide),
				[062] = new ElementData(062, "Sm", "Samarium", 8, 8, ElementGroup.Lathanide),
				[063] = new ElementData(063, "Eu", "Europium", 9, 8, ElementGroup.Lathanide),
				[064] = new ElementData(064, "Gd", "Gadolinium", 10, 8, ElementGroup.Lathanide),
				[065] = new ElementData(065, "Tb", "Terbium", 11, 8, ElementGroup.Lathanide),
				[066] = new ElementData(066, "Dy", "Dysprosium", 12, 8, ElementGroup.Lathanide),
				[067] = new ElementData(067, "Ho", "Holmium", 13, 8, ElementGroup.Lathanide),
				[068] = new ElementData(068, "Er", "Erbium", 14, 8, ElementGroup.Lathanide),
				[069] = new ElementData(069, "Tm", "Thulium", 15, 8, ElementGroup.Lathanide),
				[070] = new ElementData(070, "Yb", "Ytterbium", 16, 8, ElementGroup.Lathanide),
				[071] = new ElementData(071, "Lu", "Lutetium", 17, 8, ElementGroup.Lathanide),
				#endregion
				[072] = new ElementData(072, "Hf", "Hafnium", 4, 6, ElementGroup.TransitionMetal),
				[073] = new ElementData(073, "Ta", "Tantalum", 5, 6, ElementGroup.TransitionMetal),
				[074] = new ElementData(074, "W", "Tungsten", 6, 6, ElementGroup.TransitionMetal),
				[075] = new ElementData(075, "Re", "Rhenium", 7, 6, ElementGroup.TransitionMetal),
				[076] = new ElementData(076, "Os", "Osmium", 8, 6, ElementGroup.TransitionMetal),
				[077] = new ElementData(077, "Ir", "Iridium", 9, 6, ElementGroup.TransitionMetal),
				[078] = new ElementData(078, "Pt", "Platinum", 10, 6, ElementGroup.TransitionMetal),
				[079] = new ElementData(079, "Au", "Gold", 11, 6, ElementGroup.TransitionMetal),
				[080] = new ElementData(080, "Hg", "Mercury", 12, 6, ElementGroup.TransitionMetal),
				[081] = new ElementData(081, "Tl", "Thalium", 13, 6, ElementGroup.BasicMetal),
				[082] = new ElementData(082, "Pb", "Lead", 14, 6, ElementGroup.BasicMetal),
				[083] = new ElementData(083, "Bi", "Bismuth", 15, 6, ElementGroup.BasicMetal),
				[084] = new ElementData(084, "Po", "Polonium", 16, 6, ElementGroup.Semimetal),
				[085] = new ElementData(085, "At", "Astatine", 17, 6, ElementGroup.Halogen),
				[086] = new ElementData(086, "Rn", "Radon", 18, 6, ElementGroup.NobleGas),

				[087] = new ElementData(087, "Fr", "Francium", 1, 7, ElementGroup.AlkaliMetal),
				[088] = new ElementData(088, "Ra", "Radium", 2, 7, ElementGroup.AlkalineEarthMetal),
				#region Actinides 89-103
				[089] = new ElementData(089, "Ac", "Actinium", 3, 9, ElementGroup.Actinide),
				[090] = new ElementData(090, "Th", "Thorium", 4, 9, ElementGroup.Actinide),
				[091] = new ElementData(091, "Pa", "Proctactinium", 5, 9, ElementGroup.Actinide),
				[092] = new ElementData(092, "U", "Uranium", 6, 9, ElementGroup.Actinide),
				[093] = new ElementData(093, "Np", "Neptunium", 7, 9, ElementGroup.Actinide),
				[094] = new ElementData(094, "Pu", "Plutonium", 8, 9, ElementGroup.Actinide),
				[095] = new ElementData(095, "Am", "Americium", 9, 9, ElementGroup.Actinide),
				[096] = new ElementData(096, "Cm", "Curium", 10, 9, ElementGroup.Actinide),
				[097] = new ElementData(097, "Bk", "Berkelium", 11, 9, ElementGroup.Actinide),
				[098] = new ElementData(098, "Cf", "Californium", 12, 9, ElementGroup.Actinide),
				[099] = new ElementData(099, "Es", "Einsteinium", 13, 9, ElementGroup.Actinide),
				[100] = new ElementData(100, "Fm", "Fermium", 14, 9, ElementGroup.Actinide),
				[101] = new ElementData(101, "Md", "Mandelevium", 15, 9, ElementGroup.Actinide),
				[102] = new ElementData(102, "No", "Nobelium", 16, 9, ElementGroup.Actinide),
				[103] = new ElementData(103, "Lr", "Lawrencium", 17, 9, ElementGroup.Actinide),
				#endregion
				[104] = new ElementData(104, "Rf", "Rutherfordium", 4, 7, ElementGroup.TransitionMetal),
				[105] = new ElementData(105, "Db", "Dubnium", 5, 7, ElementGroup.TransitionMetal),
				[106] = new ElementData(106, "Sg", "Seaborgium", 6, 7, ElementGroup.TransitionMetal),
				[107] = new ElementData(107, "Bh", "Bohrium", 7, 7, ElementGroup.TransitionMetal),
				[108] = new ElementData(108, "Hs", "Hassium", 8, 7, ElementGroup.TransitionMetal),
				[109] = new ElementData(109, "Mt", "Meitnerium", 9, 7, ElementGroup.TransitionMetal),
				[110] = new ElementData(110, "Ds", "Darmstadium", 10, 7, ElementGroup.TransitionMetal),
				[111] = new ElementData(111, "Rg", "Roentgenium", 11, 7, ElementGroup.TransitionMetal),
				[112] = new ElementData(112, "Cn", "Copernicium", 12, 7, ElementGroup.TransitionMetal),
				[113] = new ElementData(113, "Nh", "Nihonium", 13, 7, ElementGroup.BasicMetal),
				[114] = new ElementData(114, "Fl", "Flerovium", 14, 7, ElementGroup.BasicMetal),
				[115] = new ElementData(115, "Mc", "Moscovium", 15, 7, ElementGroup.BasicMetal),
				[116] = new ElementData(116, "Lv", "Livermorium", 16, 7, ElementGroup.BasicMetal),
				[117] = new ElementData(117, "Ts", "Tennesine", 17, 7, ElementGroup.Halogen),
				[118] = new ElementData(118, "Og", "Oganesson", 18, 7, ElementGroup.NobleGas)
			};
			return new ReadOnlyDictionary<int, ElementData>(dict);
		}
	}
}
