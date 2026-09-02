using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BB4 RID: 23476
	public class InstanceDungeonAreaView : UiViewBase
	{
		// Token: 0x0603B63D RID: 243261 RVA: 0x00F0B949 File Offset: 0x00F09B49
		[NullableContext(1)]
		public InstanceDungeonAreaView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603B63E RID: 243262 RVA: 0x00F0B954 File Offset: 0x00F09B54
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B63F RID: 243263 RVA: 0x00F0B99C File Offset: 0x00F09B9C
		protected override void OnStart()
		{
			this.UiViewSequence.AddSequenceFinishEvent("Start", delegate(string _)
			{
				TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					base.CloseMe(null);
				}, 3000f, null, null, true, 1f);
			}, false);
		}

		// Token: 0x0603B640 RID: 243264 RVA: 0x00F0B9BC File Offset: 0x00F09BBC
		private void SetName()
		{
			if (base.GetText(0) != null)
			{
				string instanceDungeonName = ModelBase<InstanceDungeonModel>.Instance.GetInstanceDungeonName();
				if (!string.IsNullOrEmpty(instanceDungeonName))
				{
					base.GetText(0).SetText(instanceDungeonName, true);
				}
			}
		}

		// Token: 0x0603B641 RID: 243265 RVA: 0x00F0B9F3 File Offset: 0x00F09BF3
		protected override void OnBeforeShow()
		{
			this.SetName();
		}

		// Token: 0x0402179C RID: 137116
		private const int SHOW_TIME = 3000;

		// Token: 0x0200BBE7 RID: 48103
		private enum EChildCom
		{
			// Token: 0x04039F92 RID: 237458
			AreaNameText
		}
	}
}
