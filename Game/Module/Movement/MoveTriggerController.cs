using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.Movement
{
	// Token: 0x020056F4 RID: 22260
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class MoveTriggerController : ControllerBase<MoveTriggerController>
	{
		// Token: 0x06038A60 RID: 232032 RVA: 0x00E58207 File Offset: 0x00E56407
		protected override bool OnClear()
		{
			this.ClearController();
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			return true;
		}

		// Token: 0x06038A61 RID: 232033 RVA: 0x00E5822C File Offset: 0x00E5642C
		protected override bool OnInit()
		{
			AKuroMoveTriggerController.UnRegisterController();
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			return true;
		}

		// Token: 0x06038A62 RID: 232034 RVA: 0x00E58250 File Offset: 0x00E56450
		private void OnWorldDone()
		{
			this.ClearController();
			this.UeController = (Singleton<ActorSystem>.Instance.Get(AKuroMoveTriggerController.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as AKuroMoveTriggerController);
			if (this.UeController != null)
			{
				AKuroMoveTriggerController.RegisterController(this.UeController);
				this.UeController.Callback.Add(new FOnKuroMovementTrigger.FOnKuroMovementTrigger_ScriptDelegate(MoveTriggerController.<OnWorldDone>g__OverlapTaskCallback|3_0));
				this.UeController.InitAllTriggers();
			}
		}

		// Token: 0x06038A63 RID: 232035 RVA: 0x00E582C3 File Offset: 0x00E564C3
		protected override bool OnLeaveLevel()
		{
			this.ClearController();
			return true;
		}

		// Token: 0x06038A64 RID: 232036 RVA: 0x00E582CC File Offset: 0x00E564CC
		public void ClearController()
		{
			if (this.UeController != null)
			{
				Singleton<ActorSystem>.Instance.Put("MoveTriggerController.ClearController", this.UeController, null);
			}
			AKuroMoveTriggerController.UnRegisterController();
			this.UeController = null;
		}

		// Token: 0x06038A66 RID: 232038 RVA: 0x00E58304 File Offset: 0x00E56504
		[CompilerGenerated]
		internal static void <OnWorldDone>g__OverlapTaskCallback|3_0([Nullable(new byte[]
		{
			2,
			1
		})] in TArray<FOverlapActorRecord> records)
		{
			for (int i = 0; i < records.Num(); i++)
			{
				FOverlapActorRecord foverlapActorRecord = records.Get(i);
				TsBaseCharacter tsBaseCharacter = foverlapActorRecord.Actor as TsBaseCharacter;
				if (tsBaseCharacter != null && tsBaseCharacter.IsValid())
				{
					CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
					Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
					if (entity != null && entity.Valid)
					{
						ETriggerAreaType area = foverlapActorRecord.Area;
						if (area != ETriggerAreaType.Water)
						{
							if (area != ETriggerAreaType.Other)
							{
							}
						}
						else
						{
							CharacterSwimComponent swimComp = entity.GetComponent<CharacterSwimComponent>();
							if (foverlapActorRecord.EnterOverlap)
							{
								CharacterSwimComponent swimComp4 = swimComp;
								if (swimComp4 != null && swimComp4.Valid)
								{
									swimComp.InSwimTriggerCount++;
									swimComp.LogSwimTriggerCount();
								}
							}
							else
							{
								CharacterSwimComponent swimComp2 = swimComp;
								if (swimComp2 != null && swimComp2.Valid && swimComp.InSwimTriggerCount > 0)
								{
									if (swimComp.IsRole)
									{
										TimerSystem.Instance.Delay(delegate(float _)
										{
											CharacterSwimComponent swimComp3 = swimComp;
											if (swimComp3 != null && swimComp3.Valid && swimComp.InSwimTriggerCount > 0)
											{
												swimComp.InSwimTriggerCount--;
												swimComp.LogSwimTriggerCount();
											}
										}, 1000f, null, null, true, 1f);
									}
									else
									{
										swimComp.InSwimTriggerCount--;
										swimComp.LogSwimTriggerCount();
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x040204E6 RID: 132326
		private AKuroMoveTriggerController UeController;
	}
}
