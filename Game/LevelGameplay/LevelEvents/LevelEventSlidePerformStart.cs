using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BF9 RID: 27641
	public class LevelEventSlidePerformStart : LevelEventBase
	{
		// Token: 0x06044113 RID: 278803 RVA: 0x011ABA1B File Offset: 0x011A9C1B
		public LevelEventSlidePerformStart(int id) : base(id)
		{
		}

		// Token: 0x06044114 RID: 278804 RVA: 0x011ABA24 File Offset: 0x011A9C24
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CWZ, "LevelEventSlidePerformStart 参数配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			SlidePerformStart slidePerformStart = inParams as SlidePerformStart;
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			Entity entity = (baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null;
			if (entity == null)
			{
				return;
			}
			CharacterRailSlideComponent component = entity.GetComponent<CharacterRailSlideComponent>();
			if (component == null)
			{
				return;
			}
			component.StartRailSlide(slidePerformStart.SlideEntityId, slidePerformStart.SlidePerformConfig.SlopeSlidePerformDaPath, null);
		}
	}
}
