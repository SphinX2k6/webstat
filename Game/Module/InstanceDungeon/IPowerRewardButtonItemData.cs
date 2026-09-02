using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BD5 RID: 23509
	[NullableContext(1)]
	public interface IPowerRewardButtonItemData
	{
		// Token: 0x17009794 RID: 38804
		// (get) Token: 0x0603B85E RID: 243806
		// (set) Token: 0x0603B85F RID: 243807
		int PowerNum { get; set; }

		// Token: 0x17009795 RID: 38805
		// (get) Token: 0x0603B860 RID: 243808
		// (set) Token: 0x0603B861 RID: 243809
		string RewardTextId { get; set; }

		// Token: 0x17009796 RID: 38806
		// (get) Token: 0x0603B862 RID: 243810
		// (set) Token: 0x0603B863 RID: 243811
		[Nullable(new byte[]
		{
			2,
			1
		})]
		string[] RewardTextArgs { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009797 RID: 38807
		// (get) Token: 0x0603B864 RID: 243812
		// (set) Token: 0x0603B865 RID: 243813
		Action RewardCallBack { get; set; }
	}
}
