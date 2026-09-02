using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Npc.Controller
{
	// Token: 0x020048D4 RID: 18644
	[NullableContext(2)]
	[Nullable(0)]
	public class BehaviorTreeSavedData
	{
		// Token: 0x06030A62 RID: 199266 RVA: 0x00BFCD50 File Offset: 0x00BFAF50
		public FBtSaveLoadRecordItem GetNextRecord()
		{
			if (!this.IsValid())
			{
				return null;
			}
			return this.BtRecord.Items.Get(this.UsableIndex);
		}

		// Token: 0x06030A63 RID: 199267 RVA: 0x00BFCD74 File Offset: 0x00BFAF74
		public FBtSaveLoadRecordItem ConsumeRecord()
		{
			if (!this.IsValid())
			{
				return null;
			}
			TArray<FBtSaveLoadRecordItem> items = this.BtRecord.Items;
			int usableIndex = this.UsableIndex;
			this.UsableIndex = usableIndex + 1;
			return items.Get(usableIndex);
		}

		// Token: 0x06030A64 RID: 199268 RVA: 0x00BFCDAC File Offset: 0x00BFAFAC
		public bool IsValid()
		{
			FBtSaveLoadRecord btRecord = this.BtRecord;
			int num = (btRecord != null) ? btRecord.Items.Num() : 0;
			return this.Path != "" && num != 0 && this.UsableIndex < num;
		}

		// Token: 0x06030A65 RID: 199269 RVA: 0x00BFCDF4 File Offset: 0x00BFAFF4
		[NullableContext(1)]
		public BehaviorTreeSavedData DeepCopy()
		{
			BehaviorTreeSavedData behaviorTreeSavedData = new BehaviorTreeSavedData();
			behaviorTreeSavedData.Path = this.Path;
			behaviorTreeSavedData.UsableIndex = this.UsableIndex;
			if (this.BtRecord != null)
			{
				behaviorTreeSavedData.BtRecord = new FBtSaveLoadRecord();
				int num = this.BtRecord.Items.Num();
				for (int i = 0; i < num; i++)
				{
					FBtSaveLoadRecordItem fbtSaveLoadRecordItem = new FBtSaveLoadRecordItem();
					FBtSaveLoadRecordItem fbtSaveLoadRecordItem2 = this.BtRecord.Items.Get(i);
					fbtSaveLoadRecordItem.RunBehaviorNodeId = fbtSaveLoadRecordItem2.RunBehaviorNodeId;
					int num2 = fbtSaveLoadRecordItem2.SavedNodeMap.Num();
					for (int j = 0; j < num2; j++)
					{
						int key = fbtSaveLoadRecordItem2.SavedNodeMap.GetKey(j);
						int value = fbtSaveLoadRecordItem2.SavedNodeMap.Get(key);
						fbtSaveLoadRecordItem.SavedNodeMap.Add(key, value);
					}
					behaviorTreeSavedData.BtRecord.Items.Add(fbtSaveLoadRecordItem);
				}
			}
			return behaviorTreeSavedData;
		}

		// Token: 0x0401BF6D RID: 114541
		[Nullable(1)]
		public string Path = "";

		// Token: 0x0401BF6E RID: 114542
		public FBtSaveLoadRecord BtRecord;

		// Token: 0x0401BF6F RID: 114543
		private int UsableIndex;
	}
}
