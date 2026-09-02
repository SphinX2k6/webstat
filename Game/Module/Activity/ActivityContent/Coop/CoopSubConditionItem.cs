using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x020069A1 RID: 27041
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CoopSubConditionItem : GridProxyAbstract<CoopSubConditionDataBase>
	{
		// Token: 0x06043133 RID: 274739 RVA: 0x0113A4B0 File Offset: 0x011386B0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnJumpClick))
			};
		}

		// Token: 0x06043134 RID: 274740 RVA: 0x0113A544 File Offset: 0x01138744
		public override void Refresh(CoopSubConditionDataBase data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			base.GetItem(0).SetUIActive(!data.IsTaskDone());
			base.GetItem(2).SetUIActive(data.IsTaskDone());
			if (data.Target > 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.Title, new <>z__ReadOnlyArray<object>(new object[]
				{
					data.Current.ToString(),
					data.Target.ToString()
				}));
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.Title, Array.Empty<object>());
			}
			base.GetText(3).SetFontOutlineColor(FColor.FromHex(data.IsTaskDone() ? "52402c" : "4836a0"));
			bool uiactive = data.IsShowJumpBtn();
			base.GetButton(1).RootUIComp.Get().SetUIActive(uiactive);
		}

		// Token: 0x06043135 RID: 274741 RVA: 0x0113A62C File Offset: 0x0113882C
		private void OnJumpClick()
		{
			CoopTaskConfig? coopTaskConfigById = ConfigBase<CoopConfig>.Instance.GetCoopTaskConfigById(this.Data.Id);
			switch (this.Data.TaskType)
			{
			case ECoopSubConditionType.ECoopProgressSubConditionData:
				if (coopTaskConfigById.Value.ItemId != 0)
				{
					SkipTaskManager.RunByConfigId(840001, coopTaskConfigById.Value.ItemId);
				}
				if (coopTaskConfigById.Value.Condition2MapId != 0 && coopTaskConfigById.Value.Condition2MarkId != 0)
				{
					CoopSubConditionDataBase data = this.Data;
					if (data == null)
					{
						return;
					}
					data.OnJumpClick();
					return;
				}
				break;
			case ECoopSubConditionType.ECoopMapTaskSubConditionData1:
			{
				CoopSubConditionDataBase data2 = this.Data;
				if (data2 == null)
				{
					return;
				}
				data2.OnJumpClick();
				return;
			}
			case ECoopSubConditionType.ECoopMapTaskSubConditionData2:
			{
				CoopSubConditionDataBase data3 = this.Data;
				if (data3 == null)
				{
					return;
				}
				data3.OnJumpClick();
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x04025609 RID: 153097
		[Nullable(2)]
		private CoopSubConditionDataBase Data;
	}
}
