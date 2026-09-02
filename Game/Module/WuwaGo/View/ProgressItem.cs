using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.View
{
	// Token: 0x02004ABE RID: 19134
	public class ProgressItem : UiPanelBase
	{
		// Token: 0x06031E28 RID: 204328 RVA: 0x00C7BA18 File Offset: 0x00C79C18
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06031E29 RID: 204329 RVA: 0x00C7BA84 File Offset: 0x00C79C84
		protected override UniTask OnBeforeStartAsync()
		{
			ProgressItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ProgressItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031E2A RID: 204330 RVA: 0x00C7BAC8 File Offset: 0x00C79CC8
		public override void SetActive(bool active)
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(!active);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(active);
			}
			if (active && !this.LastActive)
			{
				LevelSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer != null)
				{
					sequencePlayer.PlayLevelSequenceByName("Light_Up", false, null, false);
				}
			}
			this.LastActive = active;
		}

		// Token: 0x0401D31D RID: 119581
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0401D31E RID: 119582
		private bool LastActive;

		// Token: 0x0200AB1C RID: 43804
		private enum EViewComponent
		{
			// Token: 0x040353FA RID: 218106
			PnlNml,
			// Token: 0x040353FB RID: 218107
			PnlActive
		}
	}
}
