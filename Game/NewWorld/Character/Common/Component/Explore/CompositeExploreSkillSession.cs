using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Explore
{
	// Token: 0x0200495B RID: 18779
	public class CompositeExploreSkillSession : IStaticVariableResetter
	{
		// Token: 0x060311A0 RID: 201120 RVA: 0x00C37560 File Offset: 0x00C35760
		static CompositeExploreSkillSession()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(CompositeExploreSkillSession.CreateStaticDefaultValue), new Action(CompositeExploreSkillSession.ResetStaticDefaultValue));
		}

		// Token: 0x060311A1 RID: 201121 RVA: 0x00C3757F File Offset: 0x00C3577F
		public static void CreateStaticDefaultValue()
		{
			CompositeExploreSkillSession.CompositeExploreSkillConfigs = new Dictionary<int, ICompositeExploreSkillConfig>
			{
				{
					10001035,
					new CompositeExploreSkillConfig
					{
						Name = "MotorcycleKiteHook",
						EntrySkillId = 10001035,
						ExitSkillId = 210130
					}
				}
			};
		}

		// Token: 0x060311A2 RID: 201122 RVA: 0x00C375BC File Offset: 0x00C357BC
		public static void ResetStaticDefaultValue()
		{
			CompositeExploreSkillSession.CompositeExploreSkillConfigs = null;
		}

		// Token: 0x060311A3 RID: 201123 RVA: 0x00C375C4 File Offset: 0x00C357C4
		public bool IsCompositeSessionExpired()
		{
			return this.ActiveCompositeSession != null && Singleton<Time>.Instance.Now - this.ActiveCompositeSession.CreatedTime >= 5000.0;
		}

		// Token: 0x060311A4 RID: 201124 RVA: 0x00C375F4 File Offset: 0x00C357F4
		[NullableContext(1)]
		public unsafe bool TryCleanStaleCompositeSession(int skillId, ELogModule logModule, string reason)
		{
			ICompositeSkillSession activeCompositeSession = this.ActiveCompositeSession;
			if (activeCompositeSession == null)
			{
				return false;
			}
			bool flag = this.IsCompositeSessionExpired();
			bool flag2 = skillId != activeCompositeSession.Config.EntrySkillId && skillId != activeCompositeSession.Config.ExitSkillId;
			if (flag || flag2)
			{
				Log instance = Singleton<Log>.Instance;
				ELogAuthor author = ELogAuthor.CK;
				string message = "复合探索技能会话被容错清除: " + reason;
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SkillId", skillId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CompositeName", activeCompositeSession.Config.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Expired", flag);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("UnrelatedSkill", flag2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("SessionAge", Singleton<Time>.Instance.Now - activeCompositeSession.CreatedTime);
				instance.Warn(logModule, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
				this.ActiveCompositeSession = null;
				return true;
			}
			return false;
		}

		// Token: 0x0401C450 RID: 115792
		private const int COMPOSITE_SESSION_TIMEOUT_MS = 5000;

		// Token: 0x0401C451 RID: 115793
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static Dictionary<int, ICompositeExploreSkillConfig> CompositeExploreSkillConfigs;

		// Token: 0x0401C452 RID: 115794
		[Nullable(2)]
		public ICompositeSkillSession ActiveCompositeSession;
	}
}
