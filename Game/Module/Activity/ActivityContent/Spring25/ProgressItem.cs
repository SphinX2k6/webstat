using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Spring25
{
	// Token: 0x02006366 RID: 25446
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ProgressItem : GridProxyAbstract<Spring25InfoProgressData>
	{
		// Token: 0x17009CDA RID: 40154
		// (get) Token: 0x0603FE3C RID: 261692 RVA: 0x01063684 File Offset: 0x01061884
		// (set) Token: 0x0603FE3D RID: 261693 RVA: 0x0106368C File Offset: 0x0106188C
		private UiSequencePlayer Player { get; set; }

		// Token: 0x0603FE3E RID: 261694 RVA: 0x01063698 File Offset: 0x01061898
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603FE3F RID: 261695 RVA: 0x01063704 File Offset: 0x01061904
		protected override UniTask OnBeforeStartAsync()
		{
			ProgressItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ProgressItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FE40 RID: 261696 RVA: 0x01063747 File Offset: 0x01061947
		public override void Refresh(Spring25InfoProgressData data, bool isSelected, int gridIndex)
		{
			UUITexture texture = base.GetTexture(0);
			if (texture != null)
			{
				texture.SetUIActive(!data.IsLight);
			}
			UUITexture texture2 = base.GetTexture(1);
			if (texture2 == null)
			{
				return;
			}
			texture2.SetUIActive(data.IsLight);
		}

		// Token: 0x0603FE41 RID: 261697 RVA: 0x0106377C File Offset: 0x0106197C
		public UniTask PlayBlinkAsync()
		{
			ProgressItem.<PlayBlinkAsync>d__8 <PlayBlinkAsync>d__;
			<PlayBlinkAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayBlinkAsync>d__.<>4__this = this;
			<PlayBlinkAsync>d__.<>1__state = -1;
			<PlayBlinkAsync>d__.<>t__builder.Start<ProgressItem.<PlayBlinkAsync>d__8>(ref <PlayBlinkAsync>d__);
			return <PlayBlinkAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0200C3CD RID: 50125
		[NullableContext(0)]
		private class EProgressComponent
		{
			// Token: 0x0403C500 RID: 247040
			public const int OffTexture = 0;

			// Token: 0x0403C501 RID: 247041
			public const int OnTexture = 1;
		}
	}
}
