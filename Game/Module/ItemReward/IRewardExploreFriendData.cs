using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B28 RID: 23336
	[NullableContext(1)]
	public interface IRewardExploreFriendData
	{
		// Token: 0x170096F5 RID: 38645
		// (get) Token: 0x0603B0B3 RID: 241843
		// (set) Token: 0x0603B0B4 RID: 241844
		string PlayerDesc { get; set; }

		// Token: 0x170096F6 RID: 38646
		// (get) Token: 0x0603B0B5 RID: 241845
		// (set) Token: 0x0603B0B6 RID: 241846
		string PlayerName { get; set; }

		// Token: 0x170096F7 RID: 38647
		// (get) Token: 0x0603B0B7 RID: 241847
		// (set) Token: 0x0603B0B8 RID: 241848
		string PlayerIndexPath { get; set; }

		// Token: 0x170096F8 RID: 38648
		// (get) Token: 0x0603B0B9 RID: 241849
		// (set) Token: 0x0603B0BA RID: 241850
		string PlayerIconPath { get; set; }

		// Token: 0x170096F9 RID: 38649
		// (get) Token: 0x0603B0BB RID: 241851
		// (set) Token: 0x0603B0BC RID: 241852
		int PlayerId { get; set; }

		// Token: 0x170096FA RID: 38650
		// (get) Token: 0x0603B0BD RID: 241853
		// (set) Token: 0x0603B0BE RID: 241854
		int PlayerLevel { get; set; }

		// Token: 0x170096FB RID: 38651
		// (get) Token: 0x0603B0BF RID: 241855
		// (set) Token: 0x0603B0C0 RID: 241856
		bool IsMyFriend { get; set; }

		// Token: 0x170096FC RID: 38652
		// (get) Token: 0x0603B0C1 RID: 241857
		// (set) Token: 0x0603B0C2 RID: 241858
		Action<int> OnClickCallback { get; set; }
	}
}
