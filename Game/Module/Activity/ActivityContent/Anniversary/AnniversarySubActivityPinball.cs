using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Anniversary
{
	// Token: 0x020069DF RID: 27103
	[NullableContext(2)]
	[Nullable(0)]
	public class AnniversarySubActivityPinball : AnniversarySubActivityDataBase
	{
		// Token: 0x060432EC RID: 275180 RVA: 0x0114349B File Offset: 0x0114169B
		public AnniversarySubActivityPinball(int id) : base(id)
		{
		}

		// Token: 0x1700A1F7 RID: 41463
		// (get) Token: 0x060432ED RID: 275181 RVA: 0x011434A4 File Offset: 0x011416A4
		public ActivityBaseData ActivityData
		{
			get
			{
				if (this.ActivityDataCache == null)
				{
					this.ActivityDataCache = base.GetActivityData();
				}
				return this.ActivityDataCache;
			}
		}

		// Token: 0x060432EE RID: 275182 RVA: 0x011434C0 File Offset: 0x011416C0
		public void ClickOpenView()
		{
			if (this.ActivityData != null && this.ActivityData.IsUnLock())
			{
				ControllerBase<PinballController>.Instance.OpenMainRootView(null).Forget<bool>();
			}
		}

		// Token: 0x060432EF RID: 275183 RVA: 0x011434E7 File Offset: 0x011416E7
		public bool GetNewChapter()
		{
			ActivityBaseData activityData = this.ActivityData;
			return false;
		}

		// Token: 0x060432F0 RID: 275184 RVA: 0x011434F1 File Offset: 0x011416F1
		public long GetNextLockedChapterTime()
		{
			ActivityBaseData activityData = this.ActivityData;
			return 0L;
		}

		// Token: 0x060432F1 RID: 275185 RVA: 0x011434FC File Offset: 0x011416FC
		[NullableContext(0)]
		public override ValueTuple<int, int> GetCurrentProgress()
		{
			int item = 0;
			if (this.TotalCount == 0)
			{
				IReadOnlyList<PinballTask> configList = ConfigPinballTaskAll.GetConfigList(true);
				if (configList != null)
				{
					foreach (PinballTask pinballTask in configList)
					{
						if (pinballTask.DropId > 0)
						{
							DropPackage? config = ConfigDropPackageById.GetConfig(pinballTask.DropId, true);
							if (config != null)
							{
								foreach (DicIntInt dicIntInt in config.Value.DropPreviewIter())
								{
									if (dicIntInt.Key == 74)
									{
										this.TotalCount += dicIntInt.Value;
									}
								}
							}
						}
					}
				}
			}
			return new ValueTuple<int, int>(item, this.TotalCount);
		}

		// Token: 0x04025707 RID: 153351
		private ActivityBaseData ActivityDataCache;

		// Token: 0x04025708 RID: 153352
		private int TotalCount;
	}
}
