using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006346 RID: 25414
	public class UnlockItem : GridProxyAbstract<int>
	{
		// Token: 0x0603FD3A RID: 261434 RVA: 0x0105EF20 File Offset: 0x0105D120
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnButtonClick))
			};
		}

		// Token: 0x0603FD3B RID: 261435 RVA: 0x0105EFB3 File Offset: 0x0105D1B3
		private void OnButtonClick()
		{
			if (this.SkipEntryId <= 0)
			{
				return;
			}
			SpringManorController instance = ControllerBase<SpringManorController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ExecuteSkipEntry(this.SkipEntryId, this.OnTrackPositionCallback);
		}

		// Token: 0x0603FD3C RID: 261436 RVA: 0x0105EFDC File Offset: 0x0105D1DC
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.SkipEntryId = data;
			SpringFestivalSkipEntry? skipEntryConfigById = ConfigBase<SpringManorConfig>.Instance.GetSkipEntryConfigById(data);
			if (skipEntryConfigById == null)
			{
				return;
			}
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.ShowTextNew(skipEntryConfigById.Value.Name);
			}
			bool flag = ModelBase<SpringManorModel>.Instance.ActivityData.IsSkipEntryUnLock(data);
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			if (!flag)
			{
				UUIButtonComponent button = base.GetButton(0);
				if (button == null)
				{
					return;
				}
				button.SetSelfInteractive(false);
				return;
			}
			else
			{
				bool flag2 = skipEntryConfigById.Value.JumpId > 0;
				bool flag3 = skipEntryConfigById.Value.TrackPositionLength > 0;
				bool flag4 = flag2 || flag3;
				UUIButtonComponent button2 = base.GetButton(0);
				if (button2 != null)
				{
					button2.SetSelfInteractive(flag4);
				}
				UUIItem item2 = base.GetItem(3);
				if (item2 == null)
				{
					return;
				}
				item2.SetAlpha(flag4 ? 1f : 0.3f);
				return;
			}
		}

		// Token: 0x04023DD0 RID: 146896
		private const float ARROW_DISABLE_ALPHA = 0.3f;

		// Token: 0x04023DD1 RID: 146897
		private int SkipEntryId;

		// Token: 0x04023DD2 RID: 146898
		[Nullable(2)]
		public Action OnTrackPositionCallback;
	}
}
