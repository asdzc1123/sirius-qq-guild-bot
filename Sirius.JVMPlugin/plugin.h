#pragma once


extern "C" {

	void InitJVM(void* p);

	void InitOpenApi(void* c_open_api);

	void OnStart();

	void OnStop();
}
