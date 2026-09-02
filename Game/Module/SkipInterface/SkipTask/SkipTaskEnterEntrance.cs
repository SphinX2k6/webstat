using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F28 RID: 20264
	public class SkipTaskEnterEntrance : SkipTask
	{
		// Token: 0x060345A2 RID: 214434 RVA: 0x00D1A1A0 File Offset: 0x00D183A0
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string s = (string)data[0];
			string markType = (string)data[1];
			string markId = (string)data[2];
			int entranceId = int.Parse(s);
			ControllerBase<InstanceDungeonEntranceController>.Instance.InstEntranceDetailRequest(entranceId).ContinueWith(delegate(bool isSuccess)
			{
				if (!isSuccess)
				{
					this.Finish();
				}
				if (ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceInstanceIdList.Count <= 0)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("InstanceTime", Array.Empty<object>());
					this.Finish();
					return;
				}
				EMarkType emarkType = (EMarkType)int.Parse(markType);
				int num = int.Parse(markId);
				if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.WorldMapView))
				{
					WorldMapModel instance = ModelBase<WorldMapModel>.Instance;
					EMarkType? currentFocalMarkType = instance.CurrentFocalMarkType;
					EMarkType emarkType2 = emarkType;
					if (currentFocalMarkType.GetValueOrDefault() == emarkType2 & currentFocalMarkType != null)
					{
						int? currentFocalMarkId = instance.CurrentFocalMarkId;
						int num2 = num;
						if (currentFocalMarkId.GetValueOrDefault() == num2 & currentFocalMarkId != null)
						{
							ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("IsInView", Array.Empty<object>());
							goto IL_D0;
						}
					}
					ControllerBase<WorldMapController>.Instance.FocalMarkItem(emarkType, num);
					IL_D0:
					this.Finish();
					return;
				}
				ControllerBase<WorldMapController>.Instance.FocalMarkItem(emarkType, num);
				this.Finish();
			});
		}
	}
}
