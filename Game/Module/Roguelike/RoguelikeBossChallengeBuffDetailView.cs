using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200513D RID: 20797
	public class RoguelikeBossChallengeBuffDetailView : UiViewBase
	{
		// Token: 0x0603589B RID: 219291 RVA: 0x00D70A62 File Offset: 0x00D6EC62
		[NullableContext(1)]
		public RoguelikeBossChallengeBuffDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603589C RID: 219292 RVA: 0x00D70A6C File Offset: 0x00D6EC6C
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

		// Token: 0x0603589D RID: 219293 RVA: 0x00D70AD8 File Offset: 0x00D6ECD8
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeBossChallengeBuffDetailView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeBossChallengeBuffDetailView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603589E RID: 219294 RVA: 0x00D70B1B File Offset: 0x00D6ED1B
		protected override void OnStart()
		{
			this.InitBuffData();
		}

		// Token: 0x0603589F RID: 219295 RVA: 0x00D70B23 File Offset: 0x00D6ED23
		protected override void OnBeforeDestroy()
		{
			this.CaptionItem = null;
			this.DebuffListPanel = null;
		}

		// Token: 0x060358A0 RID: 219296 RVA: 0x00D70B34 File Offset: 0x00D6ED34
		private void InitBuffData()
		{
			int[] array = (int[])this.OpenParam;
			int num = array[0];
			int num2 = array[1];
			if (num == 0)
			{
				return;
			}
			RoguelikeConfig instance = ConfigBase<RoguelikeConfig>.Instance;
			RogueTower? rogueTower = (instance != null) ? instance.GetRogueTowerConfig(num) : null;
			if (rogueTower == null)
			{
				return;
			}
			int[] array2 = rogueTower.Value.Buffs() ?? Array.Empty<int>();
			HashSet<int> hashSet = new HashSet<int>();
			List<RoguelikeBossChallengeBuffData> list = new List<RoguelikeBossChallengeBuffData>();
			foreach (int num3 in array2)
			{
				if (num3 != 0 && !hashSet.Contains(num3))
				{
					hashSet.Add(num3);
					list.Add(new RoguelikeBossChallengeBuffData
					{
						Id = num3,
						IsActive = (num3 == num2),
						DescMode = EDescModel.DETAIL
					});
				}
			}
			RoguelikeBossChallengeBuffListItem debuffListPanel = this.DebuffListPanel;
			if (debuffListPanel == null)
			{
				return;
			}
			debuffListPanel.RefreshBuffList(list);
		}

		// Token: 0x060358A1 RID: 219297 RVA: 0x00D70C15 File Offset: 0x00D6EE15
		private void OnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0401EC2F RID: 125999
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401EC30 RID: 126000
		[Nullable(2)]
		private RoguelikeBossChallengeBuffListItem DebuffListPanel;

		// Token: 0x0200B0DB RID: 45275
		private class EComponents
		{
			// Token: 0x04036DD2 RID: 224722
			public const int ItemCaption = 0;

			// Token: 0x04036DD3 RID: 224723
			public const int ItemDebuffList = 1;
		}
	}
}
