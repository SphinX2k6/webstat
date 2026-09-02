using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020025F2 RID: 9714
[NullableContext(1)]
[Nullable(0)]
public class PlatformDefine
{
	// Token: 0x06013090 RID: 77968 RVA: 0x00546E50 File Offset: 0x00545050
	// Note: this type is marked as 'beforefieldinit'.
	static PlatformDefine()
	{
		Dictionary<string, EInputControllerType> dictionary = new Dictionary<string, EInputControllerType>();
		dictionary["1356_3302"] = EInputControllerType.PS4;
		dictionary["1356_3570"] = EInputControllerType.PS4;
		dictionary["1356_1476"] = EInputControllerType.PS4;
		dictionary["1356_2508"] = EInputControllerType.PS4;
		dictionary["1118_2834"] = EInputControllerType.XboxOne;
		dictionary["1118_2835"] = EInputControllerType.XboxOne;
		dictionary["1118_2816"] = EInputControllerType.XboxOne;
		dictionary["1118_733"] = EInputControllerType.XboxOne;
		dictionary["1118_736"] = EInputControllerType.XboxOne;
		dictionary["1118_739"] = EInputControllerType.XboxOne;
		dictionary["1118_746"] = EInputControllerType.XboxOne;
		dictionary["1118_765"] = EInputControllerType.XboxOne;
		dictionary["1118_766"] = EInputControllerType.XboxOne;
		dictionary["13706_*"] = EInputControllerType.BackBone;
		dictionary["1406_8201"] = EInputControllerType.NsPro;
		dictionary["5426_*"] = EInputControllerType.XboxOne;
		dictionary["5426_4103"] = EInputControllerType.PS4;
		dictionary["5426_4112"] = EInputControllerType.PS5;
		PlatformDefine.DeviceIdMap = dictionary;
	}

	// Token: 0x04009477 RID: 38007
	private const string DualSenseWirelessController = "1356_3302";

	// Token: 0x04009478 RID: 38008
	private const string DualSenseEdgeWirelessController = "1356_3570";

	// Token: 0x04009479 RID: 38009
	private const string DualShock4_Cuhzct1x = "1356_1476";

	// Token: 0x0400947A RID: 38010
	private const string DualShock4_Cuhzct2x = "1356_2508";

	// Token: 0x0400947B RID: 38011
	private const string XboxController = "1118_2834";

	// Token: 0x0400947C RID: 38012
	private const string XboxEliteSeriersController = "1118_2835";

	// Token: 0x0400947D RID: 38013
	private const string XboxEliteSeries2Controller = "1118_2816";

	// Token: 0x0400947E RID: 38014
	private const string XboxOneController2015 = "1118_733";

	// Token: 0x0400947F RID: 38015
	private const string XboxOneWirelessController = "1118_736";

	// Token: 0x04009480 RID: 38016
	private const string XboxOneEliteController = "1118_739";

	// Token: 0x04009481 RID: 38017
	private const string XboxOneController = "1118_746";

	// Token: 0x04009482 RID: 38018
	private const string XboxOneSController = "1118_765";

	// Token: 0x04009483 RID: 38019
	private const string XboxWirelessAdapterForWindows = "1118_766";

	// Token: 0x04009484 RID: 38020
	private const string BackboneOne = "13706_*";

	// Token: 0x04009485 RID: 38021
	private const string NsPro = "1406_8201";

	// Token: 0x04009486 RID: 38022
	private const string RazerDefault = "5426_*";

	// Token: 0x04009487 RID: 38023
	private const string Razer_DualShock4 = "5426_4103";

	// Token: 0x04009488 RID: 38024
	private const string RazerWolverineV2Pro = "5426_4112";

	// Token: 0x04009489 RID: 38025
	public static readonly IReadOnlyDictionary<string, EInputControllerType> DeviceIdMap;
}
