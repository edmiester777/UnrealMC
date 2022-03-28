setlocal

cd third-party/mc-proto
mkdir build
cd build
cmake -DEXTRA_COMPILER_FLAGS="/MD" ..
cmake --build . --clean-first --config Release

endlocal