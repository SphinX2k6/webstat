using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using UnrealEngine;

// Token: 0x020025AC RID: 9644
[NullableContext(2)]
[Nullable(0)]
[RequiredMember]
public class PhotoSaveViewParam
{
	// Token: 0x06012D41 RID: 77121 RVA: 0x005349E5 File Offset: 0x00532BE5
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public PhotoSaveViewParam()
	{
	}

	// Token: 0x04009304 RID: 37636
	public bool ScreenShot;

	// Token: 0x04009305 RID: 37637
	public bool PrepareFullScreenShot;

	// Token: 0x04009306 RID: 37638
	public bool IsHiddenBattleView;

	// Token: 0x04009307 RID: 37639
	public HandBookPhotoData HandBookPhotoData;

	// Token: 0x04009308 RID: 37640
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public IReadOnlyList<GachaResult> GachaData;

	// Token: 0x04009309 RID: 37641
	public FragmentMemoryCollectData FragmentMemory;

	// Token: 0x0400930A RID: 37642
	public RoleSkinData RoleSkinData;

	// Token: 0x0400930B RID: 37643
	public VersionPreheatShareData VersionPreheat;

	// Token: 0x0400930C RID: 37644
	public Spring25ShareData Spring25Data;

	// Token: 0x0400930D RID: 37645
	public IBabelTowerSettlementViewData BabelTowerSettlementViewData;

	// Token: 0x0400930E RID: 37646
	public IWheelTowerSettlementViewData WheelTowerSettlementViewData;

	// Token: 0x0400930F RID: 37647
	public ShipTowerRecordShareData ShipTowerRecordShareData;

	// Token: 0x04009310 RID: 37648
	public UTexture2D ExternalTexture;

	// Token: 0x04009311 RID: 37649
	public string DateText;

	// Token: 0x04009312 RID: 37650
	[RequiredMember]
	public int ShareId;

	// Token: 0x04009313 RID: 37651
	public string LogoConfigName;

	// Token: 0x04009314 RID: 37652
	public bool? LogoLeft;

	// Token: 0x04009315 RID: 37653
	public bool? CaptureFullScene;

	// Token: 0x04009316 RID: 37654
	public EShareReportExtraType? ReportExtraType;
}
