using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.RoleCutIn
{
	// Token: 0x020055B7 RID: 21943
	public class PhantomArenaRoleCutInView : UiTickViewBase
	{
		// Token: 0x06037DDC RID: 228828 RVA: 0x00E27A25 File Offset: 0x00E25C25
		[NullableContext(1)]
		public PhantomArenaRoleCutInView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06037DDD RID: 228829 RVA: 0x00E27A39 File Offset: 0x00E25C39
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06037DDE RID: 228830 RVA: 0x00E27A74 File Offset: 0x00E25C74
		protected UniTask LoadRoleSkillTexture()
		{
			PhantomArenaRoleCutInView.<LoadRoleSkillTexture>d__5 <LoadRoleSkillTexture>d__;
			<LoadRoleSkillTexture>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadRoleSkillTexture>d__.<>4__this = this;
			<LoadRoleSkillTexture>d__.<>1__state = -1;
			<LoadRoleSkillTexture>d__.<>t__builder.Start<PhantomArenaRoleCutInView.<LoadRoleSkillTexture>d__5>(ref <LoadRoleSkillTexture>d__);
			return <LoadRoleSkillTexture>d__.<>t__builder.Task;
		}

		// Token: 0x06037DDF RID: 228831 RVA: 0x00E27AB8 File Offset: 0x00E25CB8
		protected void RefreshSkillName()
		{
			int roleId = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.RoleId;
			PhantomBattleCardRole phantomBattleCardRole = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRole(roleId);
			int num = phantomBattleCardRole.GetActiveSkillIdBytes().IndexOf(this.Data.SkillId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), phantomBattleCardRole.SkillNameList()[num], Array.Empty<object>());
		}

		// Token: 0x06037DE0 RID: 228832 RVA: 0x00E27B18 File Offset: 0x00E25D18
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaRoleCutInView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaRoleCutInView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037DE1 RID: 228833 RVA: 0x00E27B5B File Offset: 0x00E25D5B
		protected override void OnBeforeDestroy()
		{
			IPhantomArenaRoleCutInData data = this.Data;
			if (data == null)
			{
				return;
			}
			Action closeCallback = data.CloseCallback;
			if (closeCallback == null)
			{
				return;
			}
			closeCallback();
		}

		// Token: 0x06037DE2 RID: 228834 RVA: 0x00E27B77 File Offset: 0x00E25D77
		protected override void OnTick(float deltaTime)
		{
			if (this.TickTime < 0f)
			{
				return;
			}
			this.TickTime -= deltaTime;
			if (this.TickTime > 0f)
			{
				return;
			}
			base.CloseMe(null);
		}

		// Token: 0x0401FF9C RID: 130972
		protected float TickTime = 2000f;

		// Token: 0x0401FF9D RID: 130973
		[Nullable(1)]
		protected IPhantomArenaRoleCutInData Data;

		// Token: 0x0200B573 RID: 46451
		private class EComponentDefine
		{
			// Token: 0x04038276 RID: 230006
			public const int RoleTexture = 0;

			// Token: 0x04038277 RID: 230007
			public const int SkillName = 1;
		}
	}
}
