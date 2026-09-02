using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefenseEvent.Model
{
	// Token: 0x02004E84 RID: 20100
	[NullableContext(2)]
	public interface ITowerDefenseEventCombatInfo
	{
		// Token: 0x170088E7 RID: 35047
		// (get) Token: 0x06033EFB RID: 212731
		// (set) Token: 0x06033EFC RID: 212732
		long Uid { get; set; }

		// Token: 0x170088E8 RID: 35048
		// (get) Token: 0x06033EFD RID: 212733
		// (set) Token: 0x06033EFE RID: 212734
		long OwnerId { get; set; }

		// Token: 0x170088E9 RID: 35049
		// (get) Token: 0x06033EFF RID: 212735
		// (set) Token: 0x06033F00 RID: 212736
		int TemplateId { get; set; }

		// Token: 0x170088EA RID: 35050
		// (get) Token: 0x06033F01 RID: 212737
		// (set) Token: 0x06033F02 RID: 212738
		int CombatId { get; set; }

		// Token: 0x170088EB RID: 35051
		// (get) Token: 0x06033F03 RID: 212739
		// (set) Token: 0x06033F04 RID: 212740
		int SubTypeId { get; set; }

		// Token: 0x170088EC RID: 35052
		// (get) Token: 0x06033F05 RID: 212741
		// (set) Token: 0x06033F06 RID: 212742
		string PrefabPath { get; set; }

		// Token: 0x170088ED RID: 35053
		// (get) Token: 0x06033F07 RID: 212743
		// (set) Token: 0x06033F08 RID: 212744
		string AssetPath { get; set; }

		// Token: 0x170088EE RID: 35054
		// (get) Token: 0x06033F09 RID: 212745
		// (set) Token: 0x06033F0A RID: 212746
		int PropertyId { get; set; }

		// Token: 0x170088EF RID: 35055
		// (get) Token: 0x06033F0B RID: 212747
		// (set) Token: 0x06033F0C RID: 212748
		int? SplineId { get; set; }

		// Token: 0x170088F0 RID: 35056
		// (get) Token: 0x06033F0D RID: 212749
		// (set) Token: 0x06033F0E RID: 212750
		Dictionary<int, int> BuffIdLayers { get; set; }

		// Token: 0x170088F1 RID: 35057
		// (get) Token: 0x06033F0F RID: 212751
		// (set) Token: 0x06033F10 RID: 212752
		[Nullable(1)]
		Vector Position { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x170088F2 RID: 35058
		// (get) Token: 0x06033F11 RID: 212753
		// (set) Token: 0x06033F12 RID: 212754
		[Nullable(1)]
		Rotator Rotation { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x170088F3 RID: 35059
		// (get) Token: 0x06033F13 RID: 212755
		// (set) Token: 0x06033F14 RID: 212756
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Dictionary<ETowerDefenseEventCombatExtraInfoType, CombatExtraInfoBase> ExtraInfo { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x06033F15 RID: 212757
		[NullableContext(1)]
		void Update(ITowerDefenseEventCombatInfo other);

		// Token: 0x06033F16 RID: 212758
		bool IsValid();

		// Token: 0x06033F17 RID: 212759
		void Reset();

		// Token: 0x06033F18 RID: 212760
		void Release();

		// Token: 0x06033F19 RID: 212761
		[NullableContext(1)]
		ITowerDefenseEventCombatInfo Clone();
	}
}
