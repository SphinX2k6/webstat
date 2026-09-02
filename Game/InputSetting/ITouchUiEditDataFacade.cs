using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007016 RID: 28694
	[NullableContext(1)]
	public interface ITouchUiEditDataFacade
	{
		// Token: 0x06045786 RID: 284550
		void Init();

		// Token: 0x06045787 RID: 284551
		CommonTouchUiEditGroup? GetGroupConfig();

		// Token: 0x06045788 RID: 284552
		string[] GetResIdList();

		// Token: 0x06045789 RID: 284553
		int GetStorageId(string resId, int index);

		// Token: 0x0604578A RID: 284554
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		ValueTuple<string, int>? GetResPair(int storageId);

		// Token: 0x0604578B RID: 284555
		[return: Nullable(2)]
		ITouchUiEditData GetDefaultData(string resId, int index);

		// Token: 0x0604578C RID: 284556
		void SaveData(ITouchUiEditData[] dataList);

		// Token: 0x0604578D RID: 284557
		[return: Nullable(2)]
		ITouchUiEditData GetData(string resId, int index);

		// Token: 0x0604578E RID: 284558
		void Clear();

		// Token: 0x0604578F RID: 284559
		void ResetEditData();

		// Token: 0x1700A4DB RID: 42203
		// (get) Token: 0x06045790 RID: 284560
		int MinTouchMoveDifference { get; }

		// Token: 0x1700A4DC RID: 42204
		// (get) Token: 0x06045791 RID: 284561
		int MaxTouchMoveDifference { get; }

		// Token: 0x1700A4DD RID: 42205
		// (get) Token: 0x06045792 RID: 284562
		float MaxTouchMoveValue { get; }

		// Token: 0x1700A4DE RID: 42206
		// (get) Token: 0x06045793 RID: 284563
		float MinTouchMoveValue { get; }

		// Token: 0x1700A4DF RID: 42207
		// (get) Token: 0x06045794 RID: 284564
		float ControlScaleRate { get; }
	}
}
