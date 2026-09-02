using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Settlement
{
	// Token: 0x020065B3 RID: 26035
	public class PinballRoleGainView : UiViewBase
	{
		// Token: 0x060410E8 RID: 266472 RVA: 0x010B1550 File Offset: 0x010AF750
		[NullableContext(1)]
		public PinballRoleGainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x17009ED8 RID: 40664
		// (get) Token: 0x060410E9 RID: 266473 RVA: 0x010B1559 File Offset: 0x010AF759
		[Nullable(2)]
		public new PinballRoleGainViewParam OpenParam
		{
			[NullableContext(2)]
			get
			{
				return this.OpenParam as PinballRoleGainViewParam;
			}
		}

		// Token: 0x060410EA RID: 266474 RVA: 0x010B1568 File Offset: 0x010AF768
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickBtnMask));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060410EB RID: 266475 RVA: 0x010B1650 File Offset: 0x010AF850
		protected override UniTask OnBeforeStartAsync()
		{
			PinballRoleGainView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballRoleGainView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060410EC RID: 266476 RVA: 0x010B1694 File Offset: 0x010AF894
		protected override void OnStart()
		{
			PinballRoleConfig? pinballRoleConfigById = ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(this.OpenParam.RoleId);
			if (pinballRoleConfigById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PinballBattle;
				ELogAuthor author = ELogAuthor.CB;
				string message = "星弹奇游角色配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RoleId", this.OpenParam.RoleId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(pinballRoleConfigById.Value.RoleId);
			if (roleConfig == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.PinballBattle;
				ELogAuthor author2 = ELogAuthor.CB;
				string message2 = "角色表角色配置不存在";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("RoleId", pinballRoleConfigById.Value.RoleId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(roleConfig.Value.Name, null);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(2), "Pinball_Character_unlock", new <>z__ReadOnlySingleElementList<object>(localTextNew));
		}

		// Token: 0x060410ED RID: 266477 RVA: 0x010B1790 File Offset: 0x010AF990
		private void OnClickBtnMask()
		{
			base.CloseMe(null);
		}

		// Token: 0x0200C5B3 RID: 50611
		private enum EComponent
		{
			// Token: 0x0403CD97 RID: 249239
			SpineRoleShadow,
			// Token: 0x0403CD98 RID: 249240
			SpineRole,
			// Token: 0x0403CD99 RID: 249241
			RoleName,
			// Token: 0x0403CD9A RID: 249242
			BtnMask
		}
	}
}
